using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class RepositoryBase<T> : IBaseRepository<T> where T : class
{
    protected readonly NacoesDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public RepositoryBase(NacoesDbContext context, DbSet<T> dbSet)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public Task CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task SoftDeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}