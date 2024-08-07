using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
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
            .Include(x => x.Voluntario)
            .Include(x => x.Ministerio)
            .Where(x => x.Ativo);
    }
}