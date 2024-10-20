using AutoMapper;
using SistemaNacoes.Application.UseCases.Voluntarios.RecuperarVoluntarioParaAgendar.Dtos;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Paginacao;

namespace SistemaNacoes.Application.UseCases.Voluntarios.RecuperarVoluntarioParaAgendar;

public class RecuperarVoluntarioParaAgendar : IRecuperarVoluntarioParaAgendarUseCase
{
    #region Ctor
    private readonly IVoluntarioService _service;
    private readonly IMapper _mapper;
    private readonly IDataIndisponivelService _dataIndisponivelService;
    private readonly IPermissoesService _permissoesService;
    private readonly IAgendaService _agendaService;
    private readonly IMinisterioService _ministerioService;

    public RecuperarVoluntarioParaAgendar(IVoluntarioService service, IMapper mapper, IDataIndisponivelService dataIndisponivelService, IPermissoesService permissoesService, IAgendaService agendaService, IMinisterioService ministerioService)
    {
        _service = service;
        _mapper = mapper;
        _dataIndisponivelService = dataIndisponivelService;
        _permissoesService = permissoesService;
        _agendaService = agendaService;
        _ministerioService = ministerioService;
    }
    #endregion

    public async Task<PaginadoResult<RecuperarVoluntarioParaAgendarResult>> ExecutarAsync(RecuperarVoluntarioParaAgendarParam param)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.GET_VOLUNTARIO, "Você não tem permissão para visualizar voluntários.");

        var agenda = await _agendaService.RecuperaGaranteExisteAsync(param.AgendarId);
        var ministerio = await _ministerioService.RecuperaGaranteExisteAsync(param.MinisterioId);

        var voluntariosParaAgendar = await _service
            .RecuperarParaAgendar(agenda.Id, ministerio.Id)
            .Select(x => new RecuperarVoluntarioParaAgendarResult
            {
                VoluntarioId = x.Id,
                Nome = x.Nome
            })
            .PaginarAsync(param.Pagina, param.Tamanho);

        foreach (var voluntario in voluntariosParaAgendar.Dados)
        {
            var datas = await _dataIndisponivelService.RecuperarPorVoluntarioAsync(voluntario.VoluntarioId);
            var disponivelPorData = _dataIndisponivelService.ExisteDataDisponivel(agenda.DataInicio, agenda.DataFinal, datas);
            
            if (!disponivelPorData)
                voluntario.MotivoIndisponibilidades.Add(EMotivoIndisponibilidadeAgendamento.DataIndisponivel);
        }

        return voluntariosParaAgendar;
    }
}