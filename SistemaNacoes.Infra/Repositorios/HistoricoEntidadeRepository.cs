using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class HistoricoEntidadeRepository : RepositoryBase<HistoricoEntidade>, IHistoricoEntidadeRepository
{
    public HistoricoEntidadeRepository(NacoesDbContext context) : base(context)
    {
    }
}