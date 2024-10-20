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

        public async Task AdicionarAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task AdicionarVariosAsync(IEnumerable<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public void Atualizar(T entity)
        {
            DbSet.Update(entity);
        }

        public void RemoverPermanente(T entity)
        {
            DbSet.Remove(entity);
        }

        public Task<T?> RecuperarPorIdAsync(int id, params string[]? includes)
        {
            return BuscarAsync(x => x.Id == id, includes);

        }

        public IQueryable<T> RecuperarTodos(params string[]? includes)
        {
            return DbSet.BaseQuery(includes);
        }

        public Task<T?> BuscarAsync(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            return DbSet
                .BaseQuery(includes)
                .FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> BuscarTodos(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            return DbSet
                .BaseQuery(includes)
                .Where(predicate);
        }

        public Task<bool> AlgumAsync(Expression<Func<T, bool>> predicate)
        {
            return DbSet
                .BaseQuery()
                .AnyAsync(predicate);
        }
    }
}