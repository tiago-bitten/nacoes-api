using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Infra.Repositorios;

public class RegistroLoginRepository : IRegistroLoginRepository
{
    private readonly IRepositoryBase<RegistroLogin> _repository;

    public RegistroLoginRepository(IRepositoryBase<RegistroLogin> repository)
    {
        _repository = repository;
    }
    
    public async Task AddAsync(RegistroLogin entity)
    {
        await _repository.AddAsync(entity);
    }
    
    public IQueryable<RegistroLogin> GetAll()
    {
        return _repository.GetAll();
    }
}