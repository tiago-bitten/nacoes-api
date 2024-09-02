using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Infra.Repositorios;

public class RegistroCriacaoRepository : IRegistroCriacaoRepository
{
    private readonly IRepositoryBase<RegistroCriacao> _repositoryBase;

    public RegistroCriacaoRepository(IRepositoryBase<RegistroCriacao> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task AddAsync(RegistroCriacao registro)
    {
        await _repositoryBase.AddAsync(registro);
    }

    public IQueryable<RegistroCriacao> GetAll()
    {
        return _repositoryBase.GetAll();
    }

    public async Task AddRangeAsync(IEnumerable<RegistroCriacao> registros)
    {
        await _repositoryBase.AddRangeAsync(registros);
    }
}