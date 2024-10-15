using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IServiceBase<T> where T : EntidadeBase
{
    Task AdicionarAsync(T entidade);
    Task AdicionarVariosAsync(List<T> entidades);
    Task<bool> ExisteAsync(int id);
    Task GaranteExisteAsync(int id);
    Task<T> RecuperaGaranteExisteAsync(int id, params string[]? includes);
    Task<List<T>> RecuperaGaranteExisteVariosAsync(List<int> ids, params string[]? includes);
    void Remover(T entity);
}