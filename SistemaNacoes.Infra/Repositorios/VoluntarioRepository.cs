using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class VoluntarioRepository : RepositoryBase<Voluntario>, IVoluntarioRepository
{
    public VoluntarioRepository(NacoesDbContext context)
        : base(context)
    {
    }

    public override async Task<Voluntario> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(x => x.VoluntariosMinisterios)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public override IQueryable<Voluntario> GetAll()
    {
        return _dbSet
            .Include(x => x.VoluntariosMinisterios);
    }

    public override async Task<Voluntario> FindAsync(Expression<Func<Voluntario, bool>> predicate)
    {
        return await _dbSet
            .Include(x => x.VoluntariosMinisterios)
            .FirstOrDefaultAsync(predicate);
    }
}