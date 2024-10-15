using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Infra.Repositorios;

public class RegistroCriacaoRepository : IRegistroCriacaoRepository
{
    private readonly IRepositoryBase<HistoricoEntidade> _repositoryBase;

    public RegistroCriacaoRepository(IRepositoryBase<HistoricoEntidade> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task AddAsync(HistoricoEntidade registro)
    {
        await _repositoryBase.AdicionarAsync(registro);
    }

    public IQueryable<HistoricoEntidade> GetAll()
    {
        return _repositoryBase.RecuperarTodos();
    }

    public async Task AddRangeAsync(IEnumerable<HistoricoEntidade> registros)
    {
        await _repositoryBase.AdicionarVariosAsync(registros);
    }
}