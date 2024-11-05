using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Domain.Entidades.Infra;

public class ServiceBase<TEntidade, TRepositorio> : IServiceBase<TEntidade>
    where TEntidade : EntidadeBase
    where TRepositorio : IRepositoryBase<TEntidade>
{
    protected readonly TRepositorio Repository;

    public ServiceBase(TRepositorio repository)
    {
        Repository = repository;
    }

    #region AdicionarAsync
    public virtual async Task AdicionarAsync(TEntidade entidade)
    {
        await Repository.AdicionarAsync(entidade);
    }
    #endregion

    #region AdicionarVariosAsync
    public async Task AdicionarVariosAsync(List<TEntidade> entidades)
    {
        await Repository.AdicionarVariosAsync(entidades);
    }
    #endregion

    #region Remover
    public void Remover(TEntidade entidade)
    {
        entidade.Remover();
        Repository.Atualizar(entidade);
    }

    public void Atualizar(TEntidade entity)
    {
        Repository.Atualizar(entity);
    }

    public IQueryable<TEntidade> RecuperarTodos(params string[]? includes)
    {
        return Repository.RecuperarTodos(includes);
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
            throw new NacoesAppException($"{typeof(TEntidade)} {MensagemErroConstant.NaoEncontrado}");
    }
    #endregion

    #region RecuperaGaranteExisteAsync
    public async Task<TEntidade> RecuperaGaranteExisteAsync(int id, params string[]? includes)
    {
        await GaranteExisteAsync(id);
        return await Repository.RecuperarPorIdAsync(id, includes);
    }
    #endregion

    #region RecuperaGaranteExisteVariosAsync
    public async Task<List<TEntidade>> RecuperaGaranteExisteVariosAsync(List<int> ids, params string[]? includes)
    {
        var entidades = new List<TEntidade>();

        foreach (var id in ids)
        {
            var entidade = await RecuperaGaranteExisteAsync(id, includes);
            entidades.Add(entidade);
        }

        if (entidades.Count != ids.Count())
            throw new NacoesAppException($"{typeof(TEntidade)} {MensagemErroConstant.NaoEncontrado}");

        return entidades;
    }
    #endregion
}