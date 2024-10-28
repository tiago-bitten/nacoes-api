using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Interfaces.Services;

/**
 * C -> Entidade Composta (Alvo)
 * T -> Uma das duas entidades
 * R -> Uma das duas entidades
 */
public interface ICompostoServiceBase<C, T, R>
    where C : EntidadeBase
    where T : EntidadeBase 
    where R : EntidadeBase
{
    Task<bool> ExistsCompostoAsync(int idT, int idR, bool considerRemovido = false, params string[]? includes);
    Task EnsureExistsCompostoAsync(int idT, int idR, bool considerRemovido = false, params string[]? includes);
    Task<C> GetAndEnsureExistsCompostoAsync(int idT, int idR, bool considerRemovido = false, params string[]? includes);
}