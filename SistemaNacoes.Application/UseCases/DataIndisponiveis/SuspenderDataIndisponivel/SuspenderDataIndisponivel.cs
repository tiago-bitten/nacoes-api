using SistemaNacoes.Application.UseCases.DataIndisponiveis.SuspenderDataIndisponivel.Dtos;
using SistemaNacoes.Domain.Entidades.DataIndisponivel;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis.SuspenderDataIndisponivel;

public class SuspenderDataIndisponivel : ISuspenderDataIndisponivelUseCase
{
    #region Ctor
    private readonly IDataIndisponivelService _service;
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuarioService _ambienteService;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;

    public SuspenderDataIndisponivel(IDataIndisponivelService service, IUnitOfWork uow, IPermissoesService permissoesService, IAmbienteUsuarioService ambienteService, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _uow = uow;
        _permissoesService = permissoesService;
        _ambienteService = ambienteService;
        _historicoService = historicoService;
    }

    #endregion
    
    public async Task ExecutarAsync(SuspenderDataIndisponivelRequest request)
    {
        if (_ambienteService.Autenticado())
            await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.SuspenderDataIndisponivel, "Você não tem permissão para suspender uma data indisponível");
        
        var dataIndisponivel = await _service.RecuperaGaranteExisteAsync(request.DataIndisponivelId);
        
        await _uow.IniciarTransacaoAsync();
        _service.Suspender(dataIndisponivel);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("data_indisponiveis", dataIndisponivel.Id, "Data indisponível suspensa.");
        await _uow.CommitTransacaoAsync();
    }
}