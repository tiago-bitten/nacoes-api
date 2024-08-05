using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class AgendamentoRepository : RepositoryBase<Agendamento>
{
    public AgendamentoRepository(NacoesDbContext context)
        : base(context)
    {
    }
}