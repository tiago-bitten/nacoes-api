using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class CompostoServiceBase<C, T, R> : ServiceBase<C>, ICompostoServiceBase<C, T, R> 
    where C : EntidadeBase
    where T : EntidadeBase
    where R : EntidadeBase
{
    protected IServiceBase<C> Service;

    public CompostoServiceBase(IRepositoryBase<C> repository, IServiceBase<C> service) : base(repository)
    {
        Service = service;
    }

    public async Task<bool> ExistsCompostoAsync(int idT, int idR, bool considerRemovido = false, params string[]? includes)
    {
        var existsT = await Service.ExistsAsync(idT, considerRemovido, includes);
        var existsR = await Service.ExistsAsync(idR, considerRemovido, includes);
        
        return existsT && existsR;
    }

    public async Task EnsureExistsCompostoAsync(int idT, int idR, bool considerRemovido = false, params string[]? includes)
    {
        await Service.EnsureExistsAsync(idR, considerRemovido, includes);
        await Service.EnsureExistsAsync(idT, considerRemovido, includes);
    }

    public async Task<C> GetAndEnsureExistsCompostoAsync(int idT, int idR, bool considerRemovido = false, params string[]? includes)
    {
        await EnsureExistsCompostoAsync(idT, idR, considerRemovido, includes);
        
        return await Service.GetRepository().FindAsync
    }
}