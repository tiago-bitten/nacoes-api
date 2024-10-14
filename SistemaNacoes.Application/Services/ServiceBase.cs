using SistemaNacoes.Domain.Interfaces.Repositorios;
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
    public async Task AdicionarAsync(T entidade)
    {
        await Repository.AdicionarAsync(entidade);
    }
    #endregion
    
    #region AdicionarVariosAsync

    public async Task AdicionarVariosAsync(IEnumerable<T> entidades)
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
}