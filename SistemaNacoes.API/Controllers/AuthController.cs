using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.Auth.Entrar;
using SistemaNacoes.Application.UseCases.Auth.Entrar.Dtos;
using SistemaNacoes.Application.UseCases.Auth.RefreshToken;
using SistemaNacoes.Application.UseCases.Auth.RefreshToken.Dtos;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    #region Ctor
    private readonly IEntrarUseCase _entrar;
    private readonly IRefreshTokenUseCase _refreshToken;
    
    public AuthController(
        IEntrarUseCase entrar,
        IRefreshTokenUseCase refreshToken)
    {
        _entrar = entrar;
        _refreshToken = refreshToken;
    }
    #endregion
    
    #region Entrar
    public async Task<IActionResult> Entrar([FromBody] EntrarRequest request)
    {
        var result = await _entrar.ExecutarAsync(request);
        return Ok();
    }
    #endregion
    
    #region RefreshToken
    public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
    {
        var result = await _refreshToken.ExecutarAsync(request);
        return Ok();
    }
    #endregion
}