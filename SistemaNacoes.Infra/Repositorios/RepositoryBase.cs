using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;
using SistemaNacoes.Shared.Extensions;

namespace SistemaNacoes.Infra.Repositorios
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntidadeBase
    {
        protected readonly NacoesDbContext Context;
        protected readonly DbSet<T> DbSet;

        public RepositoryBase(NacoesDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<T?> GetByIdAsync(int id, params string[]? includes)
        {
            return await FindAsync(x => x.Id == id, includes);

        }

        public IQueryable<T> GetAll(params string[]? includes)
        {
            return DbSet.BaseQuery(includes);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            return await DbSet
                .BaseQuery(includes)
                .FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            return DbSet
                .BaseQuery(includes)
                .Where(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet
                .BaseQuery()
                .AnyAsync(predicate);
        }
    }
}