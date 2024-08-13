using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class GrupoRepository : RepositoryBase<Grupo>, IGrupoRepository
{
    public GrupoRepository(NacoesDbContext context)
        : base(context)
    {
    }

    public override void SoftDeleteAsync(Grupo entity)
    {
        entity.Removido = true;
        
        _dbSet.Update(entity);
        
        entity.GrupoVoluntarios.ForEach(x =>
        {
            x.Removido = true;
            _context.Set<GrupoVoluntario>().Update(x);
        });
    }
}