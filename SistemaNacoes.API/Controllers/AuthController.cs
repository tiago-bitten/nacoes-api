using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Auth;
using SistemaNacoes.Application.UseCases.Auth;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly RefreshToken_old _refreshTokenOld;
    private readonly Login _login;

    public AuthController(RefreshToken_old refreshTokenOld, Login login)
    {
        _refreshTokenOld = refreshTokenOld;
        _login = login;
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await _login.ExecuteAsync(dto);
        
        return Ok(result);
    }
    
    [HttpPost("RefreshToken_old")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshAuthTokenDto dto)
    {
        var result = await _refreshTokenOld.ExecuteAsync(dto);
        
        return Ok(result);
    }
}