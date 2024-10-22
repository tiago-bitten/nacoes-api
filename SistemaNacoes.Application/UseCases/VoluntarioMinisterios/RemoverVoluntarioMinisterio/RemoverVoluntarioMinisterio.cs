using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios.RemoverVoluntarioMinisterio;

public class RemoverVoluntarioMinisterio : IRemoverVoluntarioMinisterioUseCase
{
    #region Ctor
    private readonly IVoluntarioMinisterioService _service;
    private readonly IUnitOfWork _uow;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;

    public RemoverVoluntarioMinisterio(IVoluntarioMinisterioService service, IUnitOfWork uow, IPermissoesService permissoesService, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _uow = uow;
        _permissoesService = permissoesService;
        _historicoService = historicoService;
    }
    #endregion

    public async Task ExecutarAsync(int id)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.RemoverVoluntarioMinisterio, "Você não tem permissão para desvincular o voluntário ao ministério.");
        
        var voluntarioMinisterio = await _service.RecuperaGaranteExisteAsync(id);
        
        await _uow.IniciarTransacaoAsync();
        _service.Remover(voluntarioMinisterio);
        await _uow.CommitTransacaoAsync();
    }
}