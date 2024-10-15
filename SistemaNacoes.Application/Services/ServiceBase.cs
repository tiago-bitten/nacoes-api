﻿using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
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
    
    #region AdicionarAsync
    public virtual async Task AdicionarAsync(T entidade)
    {
        await Repository.AdicionarAsync(entidade);
    }
    #endregion
    
    #region AdicionarVariosAsync

    public async Task AdicionarVariosAsync(List<T> entidades)
    {
        await Repository.AdicionarVariosAsync(entidades);
    }
    #endregion
    
    #region Remover
    public void Remover(T entity)
    {
        entity.Remover();
        Repository.Atualizar(entity);
    }
    #endregion
    
    #region ExisteAsync
    public async Task<bool> ExisteAsync(int id)
    {
        return await Repository.AlgumAsync(x => x.Id == id);
    }
    #endregion

    #region GaranteExisteAsync
    public async Task GaranteExisteAsync(int id)
    {
        var exists = await ExisteAsync(id);

        if (!exists)
            throw new NacoesAppException($"{typeof(T)} {MensagemErroConstant.NaoEncontrado}");
    }
    #endregion

    #region RecuperaGaranteExisteAsync
    public async Task<T> RecuperaGaranteExisteAsync(int id, params string[]? includes)
    {
        await GaranteExisteAsync(id);

        return await Repository.RecuperarPorIdAsync(id, includes);
    }
    #endregion
    
    #region RecuperaGaranteExisteVariosAsync
    public async Task<List<T>> RecuperaGaranteExisteVariosAsync(List<int> ids, params string[]? includes)
    {
        var entidades = new List<T>();
        
        foreach (var id in ids)
        {
            var entidade = await RecuperaGaranteExisteAsync(id, includes);
            entidades.Add(entidade);
        }
        
        if (entidades.Count != ids.Count())
            throw new NacoesAppException($"{typeof(T)} {MensagemErroConstant.NaoEncontrado}");
        
        return entidades;
    }
    #endregion
}