using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class SituacaoAgendamentoRepository : RepositoryBase<SituacaoAgendamento>, ISituacaoAgendamentoRepository
{
    public SituacaoAgendamentoRepository(NacoesDbContext context) : base(context)
    {
    }

    public override IQueryable<SituacaoAgendamento> GetAll()
    {
        return _dbSet
            .Include(x => x.Agendamento);
    }
    
    public override async Task<SituacaoAgendamento> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(x => x.Agendamento)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<SituacaoAgendamento> FindAsync(Expression<Func<SituacaoAgendamento, bool>> predicate)
    {
        return await _dbSet
            .Include(x => x.Agendamento)
            .FirstOrDefaultAsync(predicate);
    }
}