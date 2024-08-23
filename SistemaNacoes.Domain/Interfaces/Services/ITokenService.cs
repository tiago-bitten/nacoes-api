using System.Security.Claims;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(string principal);
    Task<RefreshToken> GenerateRefreshTokenAsync(string principal);
    Task RevogarRefreshTokenAsync(string token);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}