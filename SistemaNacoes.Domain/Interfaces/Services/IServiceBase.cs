using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IServiceBase<T> where T : EntidadeBase
{
    Task<T> GetAndEnsureExistsAsync(int id, bool considerRemovido = false, params string[]? includes);
}