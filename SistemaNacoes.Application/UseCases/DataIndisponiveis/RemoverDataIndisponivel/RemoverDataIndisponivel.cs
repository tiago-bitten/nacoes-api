using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis.RemoverDataIndisponivel;

public class RemoverDataIndisponivel : IRemoverDataIndisponivelUseCase
{
    #region Ctor
    private readonly IDataIndisponivelService _service;
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuarioService _ambienteService;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;
    
    public RemoverDataIndisponivel(IDataIndisponivelService service, IUnitOfWork uow, IAmbienteUsuarioService ambienteService, IPermissoesService permissoesService, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _uow = uow;
        _ambienteService = ambienteService;
        _permissoesService = permissoesService;
        _historicoService = historicoService;
    }

    #endregion
    
    public async Task ExecutarAsync(int id)
    {
        if (_ambienteService.Autenticado())
            await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.DELETE_DATA_INDISPONIVEL, "Você não tem permissão para remover uma data indisponível");
        
        var dataIndisponivel = await _service.RecuperaGaranteExisteAsync(id);

        await _uow.IniciarTransacaoAsync();
        _service.Remover(dataIndisponivel);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("data_indisponiveis", dataIndisponivel.Id, "Data indisponível removida");
        await _uow.CommitTransacaoAsync();
    }
}