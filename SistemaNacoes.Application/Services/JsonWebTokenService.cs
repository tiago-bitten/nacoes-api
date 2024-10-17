using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class JsonWebTokenService : ITokenService
{
    private readonly IUnitOfWork _uow;
    private readonly IConfiguration _configuration;

    public JsonWebTokenService(IUnitOfWork uow, IConfiguration configuration)
    {
        _uow = uow;
        _configuration = configuration;
    }

    public string GenerateAccessToken(Usuario usuario)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.Email),
            new Claim(ClaimTypes.Role, ((long)usuario.PerfilAcesso.Permissoes).ToString())
        };

        var tokenOptions = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(int.Parse(_configuration["Jwt:ExpireHours"])),
            signingCredentials: signinCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    public async Task<RefreshToken> GenerateRefreshTokenAsync(string principal)
    {
        var existingTokens = await _uow.RefreshTokens
            .FindAsync(x => x.Principal == principal && !x.Revogado);

        foreach (var token in existingTokens)
        {
            token.Revogado = true;
        }

        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        var newToken = Convert.ToBase64String(randomNumber);
        var dataExpiracao = DateTime.UtcNow.AddDays(7);

        var refreshToken = new RefreshToken(newToken, principal, dataExpiracao);

        await _uow.RefreshTokens.AddAsync(refreshToken);

        return refreshToken;
    }



    public async Task RevogarRefreshTokenAsync(string token)
    {
        var refreshToken = await _uow.RefreshTokens.GetByTokenAsync(token);
        
        if (refreshToken is null)
            throw new InvalidOperationException("Refresh token not found.");
        
        _uow.RefreshTokens.Revogar(refreshToken);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Token inválido");

        return principal;
    }

}