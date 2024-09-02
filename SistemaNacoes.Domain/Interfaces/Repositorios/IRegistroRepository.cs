namespace SistemaNacoes.Domain.Interfaces.Repositorios;

public interface IRegistroRepository<T> where T : class
{
    Task AddAsync(T registro);
    Task AddRangeAsync(IEnumerable<T> registros);
    IQueryable<T> GetAll();
}