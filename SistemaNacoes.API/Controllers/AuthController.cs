using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Auth;
using SistemaNacoes.Application.UseCases.Auth;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly RefreshToken _refreshToken;

    public AuthController(RefreshToken refreshToken)
    {
        _refreshToken = refreshToken;
    }
    
    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshAuthTokenDto dto)
    {
        var result = await _refreshToken.ExecuteAsync(dto);
        
        return Ok(result);
    }
}