using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
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

    public async Task<bool> ExisteAsync(int id)
    {
        return await Repository.AnyAsync(x => x.Id == id);
    }

    public async Task GaranteExisteAsync(int id)
    {
        var exists = await ExisteAsync(id);

        if (!exists)
            throw new NacoesAppException($"{typeof(T)} {MensagemErroConstant.NaoEncontrado}");
    }

    public async Task<T> RecuperaGaranteExisteAsync(int id, params string[]? includes)
    {
        await GaranteExisteAsync(id);

        return await Repository.GetByIdAsync(id, includes);
    }

    public void Remover(T entity)
    {
        entity.Remover();
        Repository.Update(entity);
    }
}