using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly NacoesDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(NacoesDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void SoftDelete(T entity)
        {
            var propertyInfo = typeof(T).GetProperty("Removido");
            if (propertyInfo != null && propertyInfo.PropertyType == typeof(bool))
            {
                propertyInfo.SetValue(entity, true);
                _dbSet.Update(entity);
            }
            else
            {
                throw new InvalidOperationException("Entity does not have a 'Removido' property or it is not of type bool.");
            }
        }

        public virtual async Task<T> GetByIdAsync(int id, params string[]? includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public virtual IQueryable<T> GetAll(params string[]? includes)
        {
            if (includes == null || includes.Length == 0)
                return _dbSet;
            
            var query = _dbSet.AsQueryable();

            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            if (includes == null || includes.Length == 0)
                return await _dbSet.FirstOrDefaultAsync(predicate);
            
            var query = _dbSet.AsQueryable();
            
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            
            return await query.FirstOrDefaultAsync(predicate);
        }

        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            if (includes == null || includes.Length == 0)
                return _dbSet.Where(predicate);
            
            var query = _dbSet.AsQueryable();
            
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            
            return query.Where(predicate);
        }
    }
}