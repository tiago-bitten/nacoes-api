using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Entidades.Ministerio;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Ministerios.RemoverMinisterio;

public class RemoverMinisterio : IRemoverMinisterioUseCase
{
    private readonly IMinisterioService _service;
    private readonly IUnitOfWork _uow;
    private readonly IHistoricoEntidadeService _historicoService;
    private readonly IPermissoesService _permissoesService;

    public RemoverMinisterio(IHistoricoEntidadeService historicoService, IMinisterioService service, IUnitOfWork uow, IPermissoesService permissoesService)
    {
        _historicoService = historicoService;
        _service = service;
        _uow = uow;
        _permissoesService = permissoesService;
    }

    public async Task ExecutarAsync(int id)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.RemoverMinisterio, "Você não possui permissão para remover ministérios");

        var ministerio = await _service.RecuperaGaranteExisteAsync(id);
        
        await _uow.IniciarTransacaoAsync();
        _service.Remover(ministerio);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("ministerios", ministerio.Id, "Removeu ministério.");
        await _uow.CommitTransacaoAsync();
    }
}