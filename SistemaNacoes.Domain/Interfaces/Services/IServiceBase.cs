using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IServiceBase<T> where T : EntidadeBase
{
    Task<bool> ExistsAsync(int id, bool considerRemovido = false, params string[]? includes);
    Task EnsureExistsAsync(int id, bool considerRemovido = false, params string[]? includes);
    Task<T> GetAndEnsureExistsAsync(int id, bool considerRemovido = false, params string[]? includes);
    IRepositoryBase<T> GetRepository();
}