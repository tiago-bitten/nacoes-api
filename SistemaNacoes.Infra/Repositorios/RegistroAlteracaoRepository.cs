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
        await _repositoryBase.AddAsync(registro);
    }

    public IQueryable<RegistroAlteracao> GetAll()
    {
        return _repositoryBase.GetAll();
    }
}