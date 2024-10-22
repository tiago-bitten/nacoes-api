using AutoMapper;
using SistemaNacoes.Application.UseCases.DataIndisponiveis.CriarDataIndisponivel.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Helpers;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis.CriarDataIndisponivel;

public class CriarDataIndisponivel : ICriarDataIndisponivelUseCase
{
    #region Ctor
    private readonly IDataIndisponivelService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;
    private readonly IAmbienteUsuarioService _ambienteService;
    private readonly IVoluntarioService _voluntarioService;

    public CriarDataIndisponivel(IDataIndisponivelService service, IMapper mapper, IUnitOfWork uow, IPermissoesService permissoesService, IHistoricoEntidadeService historicoService, IAmbienteUsuarioService usuarioService, IVoluntarioService voluntarioService)
    {
        _service = service;
        _mapper = mapper;
        _uow = uow;
        _permissoesService = permissoesService;
        _historicoService = historicoService;
        _ambienteService = usuarioService;
        _voluntarioService = voluntarioService;
    }
    #endregion

    public async Task<CriarDataIndisponivelResult> ExecutarAsync(CriarDataIndisponivelRequest request)
    {
        if (_ambienteService.Autenticado())
            await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CriarDataIndisponivel, "Você não tem permissão para criar uma data indisponível");
        
        var volutario = await _voluntarioService.RecuperarPorChaveAcessoAsync(GuidHelper.Converter(request.VoluntarioChaveAcesso));
        
        var dataIndisponivel = _mapper.Map<DataIndisponivel>(request);
        
        dataIndisponivel.Voluntario = volutario;

        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarAsync(dataIndisponivel);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("data_indisponiveis", dataIndisponivel.Id, "Data indisponível criada");
        await _uow.CommitTransacaoAsync();

        var result = _mapper.Map<CriarDataIndisponivelResult>(dataIndisponivel);

        return result;
    }
}