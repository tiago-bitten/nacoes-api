namespace SistemaNacoes.Shared.Helpers;

public static class GuidHelper
{
    public static Guid Converter(string stringGuid)
    {
        if (Guid.TryParse(stringGuid, out var guid))
            return guid;
        
        throw new InvalidOperationException($"'{stringGuid}' não é um Guid válido.");
    }
}