using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.AgendamentoAtividade;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class AgendamentoAtividadeRepository : RepositoryBase<AgendamentoAtividade>, IAgendamentoAtividadeRepository
{
    public AgendamentoAtividadeRepository(NacoesDbContext context)
        : base(context)
    {
    }
}