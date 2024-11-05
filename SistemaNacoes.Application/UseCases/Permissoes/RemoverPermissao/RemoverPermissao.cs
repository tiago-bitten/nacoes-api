using SistemaNacoes.Application.UseCases.Permissoes.RemoverPermissao.Dtos;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Entidades.PerfilAcesso;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Extensions;

namespace SistemaNacoes.Application.UseCases.Permissoes.RemoverPermissao;

public class RemoverPermissao : IRemoverPermissaoUseCase
{
    #region Ctor
    private readonly IPermissoesService _service;
    private readonly IUnitOfWork _uow;
    private readonly IPerfilAcessoService _perfilAcessoService;
    private readonly IHistoricoEntidadeService _historicoService;
    
    public RemoverPermissao(IPermissoesService service, IPerfilAcessoService perfilAcessoService, IHistoricoEntidadeService historicoService, IUnitOfWork uow)
    {
        _service = service;
        _perfilAcessoService = perfilAcessoService;
        _historicoService = historicoService;
        _uow = uow;
    }

    #endregion
    
    public async Task ExecutarAsync(RemoverPermissaoRequest request)
    {
        await _service.VerificaGarantePermissaoAsync(EPermissoes.AtualizarPerfilAcesso,
            "Você não possui permissão para remover permissões de um perfil de acesso.");
        
        var perfilAcesso = await _perfilAcessoService.RecuperaGaranteExisteAsync(request.PerfilAcessoId);
        
        var removerPemissoes = request.PermissoesId.ToArray();
        perfilAcesso.RemoverPermissao(removerPemissoes);
        
        await _uow.IniciarTransacaoAsync();
        _perfilAcessoService.Atualizar(perfilAcesso);
        await _uow.CommitTransacaoAsync();
        
        var descricao = removerPemissoes.Length > 1 ? "Permissões removidas do perfil de acesso." : "Permissão removida do perfil de acesso.";
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("perfil_acessos", perfilAcesso.Id, descricao);
        await _uow.CommitTransacaoAsync();
    }
}