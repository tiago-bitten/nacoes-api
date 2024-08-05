using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Interfaces;
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

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void SoftDeleteAsync(T entity)
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

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}