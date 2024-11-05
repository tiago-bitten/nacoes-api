using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Shared.Extensions
{
    public static class QueryExtensions
    {
        // TODO: rever e refatorar
        #region SelectFields
        public static IQueryable<Dictionary<string, object>> SelectFields<T>(this IQueryable<T> source, List<string> fields) where T : class
        {
            return source.AsEnumerable().Select(item =>
            {
                var result = new Dictionary<string, object>();

                foreach (var field in fields)
                {
                    var parts = field.Split('.');
                    var currentObj = (object)item;
                    Dictionary<string, object> currentDict = result;

                    for (int i = 0; i < parts.Length; i++)
                    {
                        var part = parts[i];
                        var property = currentObj.GetType().GetProperty(part);
                        if (property == null)
                            throw new ArgumentException($"Propriedade '{part}' não está na entidade '{currentObj.GetType().Name}'");

                        var value = property.GetValue(currentObj);

                        if (i == parts.Length - 1)
                        {
                            currentDict[part] = value;
                        }
                        else
                        {
                            if (!currentDict.ContainsKey(part))
                            {
                                var newDict = new Dictionary<string, object>();
                                currentDict[part] = newDict;
                                currentDict = newDict;
                            }
                            else
                            {
                                currentDict = (Dictionary<string, object>)currentDict[part];
                            }

                            currentObj = value;
                        }
                    }
                }

                return result;
            }).AsQueryable();
        }
        #endregion

        #region WhereNotRemovido
        public static IQueryable<T> WhereNotRemovido<T>(this IQueryable<T> source, Expression<Func<T, bool>>? condicaoAdicional = null) where T : EntidadeBase
        {
            var query = source.Where(entidade => !entidade.Removido);

            if (condicaoAdicional is not null)
                query = query.Where(condicaoAdicional);

            return query;
        }
        #endregion
        
        #region ApplyIncludes
        public static IQueryable<T> ApplyIncludes<T>(this IQueryable<T> query, params string[]? includes) where T : class
        {
            return includes == null ? query : includes.Aggregate(query, (current, include) => current.Include(include));
        }
        #endregion
        
        #region BaseQuery
        public static IQueryable<T> BaseQuery<T>(this IQueryable<T> query, params string[]? includes) where T : EntidadeBase
        {
            return query
                .ApplyIncludes(includes)
                .WhereNotRemovido();
        }
        #endregion
    }
}
