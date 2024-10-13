using System.Linq.Expressions;

namespace SistemaNacoes.Domain.Interfaces.Repositorios
{
    public interface IRepositoryBase<T>
    {
        Task AdicionarAsync(T entity);
        Task AdicionarVariosAsync(IEnumerable<T> entities);
        void Atualizar(T entity);
        void RemoverPermanente(T entity);
        Task<T?> RecuperarPorIdAsync(int id, params string[]? includes);
        IQueryable<T> RecuperarTodos(params string[]? includes);
        Task<T?> BuscarAsync(Expression<Func<T, bool>> predicate, params string[]? includes);
        IQueryable<T> BuscarTodos(Expression<Func<T, bool>> predicate, params string[]? includes);
        Task<bool> AlgumAsync(Expression<Func<T, bool>> predicate);
    }
}