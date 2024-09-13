using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
using System.Reflection;
using SistemaNacoes.Application.Responses;
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

    public virtual async Task<bool> ExistsAsync(int id, bool considerRemovido = false, params string[]? includes)
    {
        return await Repository.AnyAsync(x => x.Id == id && x.Removido == considerRemovido);
    }

    public virtual async Task EnsureExistsAsync(int id, bool considerRemovido = false, params string[]? includes)
    {
        var exists = await ExistsAsync(id, considerRemovido, includes);

        if (!exists)
            throw new NacoesAppException($"{typeof(T)} {MensagemErroConstant.NaoEncontrado}");
    }

    public virtual async Task<T> GetAndEnsureExistsAsync(int id, bool considerRemovido = false, params string[]? includes)
    {
        await EnsureExistsAsync(id, considerRemovido, includes);
        
        return await Repository.GetByIdAsync(id);
    }

    public IRepositoryBase<T> GetRepository()
    {
        return Repository;
    }
}