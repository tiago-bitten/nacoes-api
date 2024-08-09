using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class ServiceBase<T> : IServiceBase<T> where T : class
{
    protected readonly IRepositoryBase<T> _repository;

    public ServiceBase(IRepositoryBase<T> repository)
    {
        _repository = repository;
    }

    public async Task<T> GetAndValidateEntityAsync(int id)
    {
        var exists = await _repository.GetByIdAsync(id);
        
        if (exists == null)
            throw new Exception("Forneça um id válido");
        
        return exists;
    }
}