using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Voluntarios.RemoverVoluntario;

public class RemoverVoluntario : IRemoverVoluntarioUseCase
{
    #region Ctor
    private readonly IVoluntarioService _service;
    private readonly IUnitOfWork _uow;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;

    public RemoverVoluntario(IVoluntarioService service, IUnitOfWork uow, IPermissoesService permissoesService, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _uow = uow;
        _permissoesService = permissoesService;
        _historicoService = historicoService;
    }

    #endregion
    
    public async Task ExecutarAsync(int id)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.DELETE_VOLUNTARIO,
            "Você não tem permissão para remover voluntários.");

        var voluntario = await _service.RecuperaGaranteExisteAsync(id);
        
        await _uow.IniciarTransacaoAsync();
        _service.Remover(voluntario);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("voluntarios", voluntario.Id, "Voluntário removido.");
        await _uow.CommitTransacaoAsync();
    }
}