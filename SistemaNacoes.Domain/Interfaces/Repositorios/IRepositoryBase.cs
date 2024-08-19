using System.Linq.Expressions;

namespace SistemaNacoes.Domain.Interfaces.Repositorios
{
    public interface IRepositoryBase<T>
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SoftDeleteAsync(T entity);
        Task<T> GetByIdAsync(int id, params string[]? includes);
        IQueryable<T> GetAll(params string[]? includes);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate, params string[]? includes);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params string[]? includes);
    }
}