using AutoMapper;
using SistemaNacoes.Application.UseCases.Voluntarios.RecuperarVoluntarioParaAgendar.Dtos;
using SistemaNacoes.Domain.Entidades.Agenda;
using SistemaNacoes.Domain.Entidades.DataIndisponivel;
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
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.VisualizarVoluntario, "Você não tem permissão para visualizar voluntários.");

        var agenda = await _agendaService.RecuperaGaranteExisteAsync(param.AgendarId);
        var ministerio = await _ministerioService.RecuperaGaranteExisteAsync(param.MinisterioId);

        var voluntariosParaAgendar = await _service
            .RecuperarParaAgendar(agenda.Id, ministerio.Id)
            .PaginarAsync(param.Pagina, param.Tamanho);

        var result = new List<RecuperarVoluntarioParaAgendarResult>();
        
        foreach (var voluntario in voluntariosParaAgendar.Dados)
        {
            result.Add(RecuperarVoluntarioParaAgendarResult.Criar(voluntario));

            var datas = voluntario.DataIndisponiveis;
            var disponivelPorData = _dataIndisponivelService.ExisteDataDisponivel(agenda.DataInicio, agenda.DataFinal, datas);
            
            if (!disponivelPorData)
                result.Last().MotivoIndisponibilidades.Add(EMotivoIndisponibilidadeAgendamento.DataIndisponivel);
        }

        var resultPaginado = result.ConverterDadosPaginacao(voluntariosParaAgendar);

        return resultPaginado;
    }
}