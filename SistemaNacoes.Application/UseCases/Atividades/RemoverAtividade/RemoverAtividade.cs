using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Atividades.RemoverAtividade;

public class RemoverAtividade : IRemoverAtividadeUseCase
{
    #region Ctor
    private readonly IAtividadeService _service;
    private readonly IUnitOfWork _uow;
    private readonly IHistoricoEntidadeService _historicoService;
    private readonly IPermissoesService _permissoesService;

    public RemoverAtividade(IAtividadeService service, IUnitOfWork uow, IHistoricoEntidadeService historicoService, IPermissoesService permissoesService)
    {
        _service = service;
        _uow = uow;
        _historicoService = historicoService;
        _permissoesService = permissoesService;
    }
    #endregion
    
    public async Task ExecutarAsync(int id)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.RemoverAtividade, "Você não possui permissão para remover atividades");
        
        var atividade = await _service.RecuperaGaranteExisteAsync(id);
        
        await _uow.IniciarTransacaoAsync();
        _service.Remover(atividade);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("atividades", atividade.Id, "Removeu atividade.");
        await _uow.CommitTransacaoAsync();
    }
}