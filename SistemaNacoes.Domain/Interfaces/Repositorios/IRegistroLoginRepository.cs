using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Repositorios;

public interface IRegistroLoginRepository
{
    Task AddAsync(RegistroLogin entity);
    IQueryable<RegistroLogin> GetAll();
}