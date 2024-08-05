using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class AgendaRepository : RepositoryBase<Agenda>
{
    public AgendaRepository(NacoesDbContext context)
        : base(context)
    {
    }
}