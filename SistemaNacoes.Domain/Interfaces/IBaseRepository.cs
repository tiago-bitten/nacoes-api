using System.Linq.Expressions;

namespace SistemaNacoes.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SoftDeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);
    }
}