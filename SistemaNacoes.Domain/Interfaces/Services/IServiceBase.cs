namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IServiceBase<T> where T : class
{
    Task<T> GetAndEnsureExistsAsync(int id);
}