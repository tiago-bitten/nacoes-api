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
        await _repositoryBase.AdicionarAsync(registro);
    }

    public IQueryable<RegistroCriacao> GetAll()
    {
        return _repositoryBase.RecuperarTodos();
    }

    public async Task AddRangeAsync(IEnumerable<RegistroCriacao> registros)
    {
        await _repositoryBase.AdicionarVariosAsync(registros);
    }
}