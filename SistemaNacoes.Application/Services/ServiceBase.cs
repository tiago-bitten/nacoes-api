using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
using System.Reflection;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Application.Services;

public class ServiceBase<T> : IServiceBase<T> where T : EntidadeBase
{
    protected readonly IRepositoryBase<T> Repository;

    public ServiceBase(IRepositoryBase<T> repository)
    {
        Repository = repository;
    }

    public virtual async Task<T> GetAndEnsureExistsAsync(int id, bool removido = false, params string[]? includes)
    {
        var entity = await Repository.GetByIdAsync(id, includes);
        
        if (entity == null)
            throw new NacoesAppException("Forneça um id válido");
        
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