using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Infra.Repositorios;

public class RegistroAlteracaoRepository : IRegistroAlteracaoRepository
{
    private readonly IRepositoryBase<RegistroAlteracao> _repositoryBase;

    public RegistroAlteracaoRepository(IRepositoryBase<RegistroAlteracao> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task AddAsync(RegistroAlteracao registro)
    {
        await _repositoryBase.AdicionarAsync(registro);
    }

    public async Task AddRangeAsync(IEnumerable<RegistroAlteracao> registros)
    {
        await _repositoryBase.AdicionarVariosAsync(registros);
    }

    public IQueryable<RegistroAlteracao> GetAll()
    {
        return _repositoryBase.RecuperarTodos();
    }
}