using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IServiceBase<T> where T : EntidadeBase
{
    Task<bool> ExisteAsync(int id);
    Task GaranteExisteAsync(int id);
    Task<T> RecuperaGaranteExisteAsync(int id, params string[]? includes);
    void Remover(T entity);
}