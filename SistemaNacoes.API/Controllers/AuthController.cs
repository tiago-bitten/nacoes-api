using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Controllers.Infra;
using SistemaNacoes.Application.UseCases.Auth.Entrar;
using SistemaNacoes.Application.UseCases.Auth.Entrar.Dtos;
using SistemaNacoes.Application.UseCases.Auth.RefreshToken;
using SistemaNacoes.Application.UseCases.Auth.RefreshToken.Dtos;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerNacoes
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
    [HttpPost("Entrar")]
    public async Task<IActionResult> Entrar([FromBody] EntrarRequest request)
    {
        var result = await _entrar.ExecutarAsync(request);
        return RespostaSucesso(result, "Login realizado com sucesso.");
    }
    #endregion
    
    #region RefreshToken
    [HttpPut("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var result = await _refreshToken.ExecutarAsync(request);
        return RespostaSucesso(result, "Token atualizado com sucesso.");
    }
    #endregion
}