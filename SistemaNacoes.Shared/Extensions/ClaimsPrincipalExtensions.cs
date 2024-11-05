using System.Security.Claims;

namespace SistemaNacoes.Shared.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int RecuperarNameIdentifier(this ClaimsPrincipal principal)
    {
        var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
        var valor = claim?.Value ?? "0";

        return int.Parse(valor);
    }
}