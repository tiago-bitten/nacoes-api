namespace SistemaNacoes.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<int> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T?>> GetAllAsync();
    }
}