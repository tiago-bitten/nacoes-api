using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.HistoricoLogin;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class HistoricoLoginRepository : RepositoryBase<HistoricoLogin>, IHistoricoLoginRepository
{
    public HistoricoLoginRepository(NacoesDbContext context) : base(context)
    {
    }
}