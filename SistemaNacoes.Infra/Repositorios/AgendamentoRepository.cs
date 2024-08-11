using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class AgendamentoRepository : RepositoryBase<Agendamento>, IAgendamentoRepository
{
    public AgendamentoRepository(NacoesDbContext context)
        : base(context)
    {
    }

    public override IQueryable<Agendamento> GetAll()
    {
        return _dbSet
            .Include(x => x.Voluntario)
            .Include(x => x.Ministerio)
            .Include(x => x.SituacaoAgendamento)
            .Include(x => x.AgendamentoAtividades).ThenInclude(x => x.Atividade);
    }

    public override async Task<Agendamento> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(x => x.Voluntario)
            .Include(x => x.Ministerio)
            .Include(x => x.SituacaoAgendamento)
            .Include(x => x.AgendamentoAtividades).ThenInclude(x => x.Atividade)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}