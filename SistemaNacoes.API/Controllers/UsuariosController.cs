using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Usuarios;
using SistemaNacoes.Application.UseCases.Usuarios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly CreateUsuario _createUsuario;

    public UsuariosController(CreateUsuario createUsuario)
    {
        _createUsuario = createUsuario;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CreateUsuarioDto dto)
    {
        var result = await _createUsuario.ExecuteAsync(dto);
        
        return Ok(result);
    }
}