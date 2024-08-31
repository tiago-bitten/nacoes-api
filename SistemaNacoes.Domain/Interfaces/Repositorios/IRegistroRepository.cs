namespace SistemaNacoes.Domain.Interfaces.Repositorios;

public interface IRegistroRepository<T> where T : class
{
    Task AddAsync(T registro);
    IQueryable<T> GetAll();
}