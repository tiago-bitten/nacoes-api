using SistemaNacoes.Application.UseCases.Permissoes.AdicionarPermissao.Dtos;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.PerfilAcesso;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Extensions;

namespace SistemaNacoes.Application.UseCases.Permissoes.AdicionarPermissao;

public class AdicionarPermissao : IAdicionarPermissaoUseCase
{
    #region Ctor
    private readonly IPermissoesService _service;
    private readonly IPerfilAcessoService _perfilAcessoService;
    private readonly IUnitOfWork _uow;
    private readonly IHistoricoEntidadeService _historicoService;
    
    public AdicionarPermissao(IPermissoesService service, IPerfilAcessoService perfilAcessoService, IUnitOfWork uow, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _perfilAcessoService = perfilAcessoService;
        _uow = uow;
        _historicoService = historicoService;
    }
    #endregion

    public async Task ExecutarAsync(AdicionarPermissaoRequest request)
    {
        await _service.VerificaGarantePermissaoAsync(EPermissoes.AtualizarPerfilAcesso,
            "Você não possui permissão para alterar um perfil de acesso.");

        var perfilAcesso = await _perfilAcessoService.RecuperaGaranteExisteAsync(request.PerfilAcessoId);

        var novasPermissoes = request.PermissoesId.ToArray();
        perfilAcesso.AdicionarPermissao(novasPermissoes);
        
        await _uow.IniciarTransacaoAsync();
        _perfilAcessoService.Atualizar(perfilAcesso);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("perfil_acessos", perfilAcesso.Id, "Permissões adicionadas ao perfil de acesso.");
        await _uow.CommitTransacaoAsync();
    }
}