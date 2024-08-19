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

    public override void SoftDeleteAsync(VoluntarioMinisterio entity)
    {
        entity.Ativo = false;
        _dbSet.Update(entity);
    }
}