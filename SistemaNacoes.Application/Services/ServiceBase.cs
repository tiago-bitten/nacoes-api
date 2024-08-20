using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
using System.Reflection;

namespace SistemaNacoes.Application.Services;

public class ServiceBase<T> : IServiceBase<T> where T : class
{
    protected readonly IRepositoryBase<T> _repository;

    public ServiceBase(IRepositoryBase<T> repository)
    {
        _repository = repository;
    }

    public virtual async Task<T> GetAndEnsureExistsAsync(int id, params string[]? includes)
    {
        var entity = await _repository.GetByIdAsync(id, includes);
        
        if (entity == null)
            throw new Exception("Forneça um id válido");
        
        var propertyInfo = typeof(T).GetProperty("Removido", BindingFlags.Public | BindingFlags.Instance);
        if (propertyInfo != null && propertyInfo.PropertyType == typeof(bool))
        {
            var isDeleted = (bool)propertyInfo.GetValue(entity);
            if (isDeleted)
                throw new Exception("Entidade removida");
        }
        return entity;
    }
}