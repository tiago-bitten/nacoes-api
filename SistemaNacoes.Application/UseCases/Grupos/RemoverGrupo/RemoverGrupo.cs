using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Grupos.RemoverGrupo;

public class RemoverGrupo : IRemoverGrupoUseCase
{
    private readonly IGrupoService _service;
    private readonly IUnitOfWork _uow;
    private readonly IHistoricoEntidadeService _historicoService;
    private readonly IPermissoesService _permissoesService;

    public RemoverGrupo(IGrupoService service, IUnitOfWork uow, IHistoricoEntidadeService historicoService, IPermissoesService permissoesService)
    {
        _service = service;
        _uow = uow;
        _historicoService = historicoService;
        _permissoesService = permissoesService;
    }

    public async Task ExecutarAsync(int id)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.DELETE_GRUPO, "Você não tem permissão para remover um grupo.");
        
        var grupo = await _service.RecuperaGaranteExisteAsync(id);
        
        await _uow.IniciarTransacaoAsync();
        _service.Remover(grupo);
        await _uow.CommitTransacaoAsync();
    }
}