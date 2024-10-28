using System.Security.Claims;

namespace SistemaNacoes.Domain.Entidades.Infra;

public interface ITokenService
{
    string GenerateAccessToken(Usuario usuario);
    Task<RefreshToken.RefreshToken> GenerateRefreshTokenAsync(string principal);
    Task RevogarRefreshTokenAsync(string token);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}