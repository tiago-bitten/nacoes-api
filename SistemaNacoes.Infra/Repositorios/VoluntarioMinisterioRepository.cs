using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class VoluntarioMinisterioRepository : RepositoryBase<VoluntarioMinisterio>, IVoluntarioMinisterioRepository
{
    public VoluntarioMinisterioRepository(NacoesDbContext context)
        : base(context)
    {
    }

    public override IQueryable<VoluntarioMinisterio> GetAll()
    {
        return _dbSet
            .Include(x => x.Voluntario).ThenInclude(x => x.Agendamentos).ThenInclude(x => x.SituacaoAgendamento)
            .Include(x => x.Voluntario).ThenInclude(x => x.Agendamentos).ThenInclude(x => x.Agenda)
            .Include(x => x.Ministerio).ThenInclude(x => x.Atividades)
            .Where(x => x.Ativo);
    }
    
    public async Task<VoluntarioMinisterio> GetAndEnsureExistsAsync(int voluntarioId, int ministerioId)
    {
        return await _dbSet
            .Include(x => x.Voluntario).ThenInclude(x => x.Agendamentos).ThenInclude(x => x.SituacaoAgendamento)
            .Include(x => x.Voluntario).ThenInclude(x => x.Agendamentos).ThenInclude(x => x.Agenda)
            .Include(x => x.Ministerio).ThenInclude(x => x.Atividades)
            .FirstOrDefaultAsync(x => x.VoluntarioId == voluntarioId && x.MinisterioId == ministerioId && x.Ativo);
    }

    public async override Task<VoluntarioMinisterio> FindAsync(Expression<Func<VoluntarioMinisterio, bool>> predicate)
    {
        return await _dbSet
            .Include(x => x.Voluntario).ThenInclude(x => x.Agendamentos).ThenInclude(x => x.SituacaoAgendamento)
            .Include(x => x.Voluntario).ThenInclude(x => x.Agendamentos).ThenInclude(x => x.Agenda)
            .Include(x => x.Ministerio).ThenInclude(x => x.Atividades)
            .FirstOrDefaultAsync(predicate);
    }

    public override void SoftDeleteAsync(VoluntarioMinisterio entity)
    {
        entity.Ativo = false;
        _dbSet.Update(entity);
    }
}