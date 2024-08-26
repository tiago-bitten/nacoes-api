namespace SistemaNacoes.Application.Extensions
{
    public static class QueryExtensions
    {
        // TODO: Refatorar esse método para atender a seleção personalizado de campos em uma query
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
    }
}
