using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class AgendaRepository : RepositoryBase<Agenda>, IAgendaRepository
{
    public AgendaRepository(NacoesDbContext context)
        : base(context)
    {
    }
    
    public override IQueryable<Agenda> GetAll()
    {
        return _dbSet
            .Include(x => x.Agendamentos);
    }

    public async override Task<Agenda> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(x => x.Agendamentos)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async override Task<Agenda> FindAsync(Expression<Func<Agenda, bool>> predicate)
    {
        return await _dbSet
            .Include(x => x.Agendamentos)
            .FirstOrDefaultAsync(predicate);
    }
}