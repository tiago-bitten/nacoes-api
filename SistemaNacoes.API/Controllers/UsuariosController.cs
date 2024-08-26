using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Usuarios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Application.UseCases.Usuarios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly CreateUsuario _createUsuario;
    private readonly GetAllUsuarios _getAllUsuarios;

    public UsuariosController(CreateUsuario createUsuario, GetAllUsuarios getAllUsuarios)
    {
        _createUsuario = createUsuario;
        _getAllUsuarios = getAllUsuarios;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CreateUsuarioDto dto)
    {
        var result = await _createUsuario.ExecuteAsync(dto);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] QueryParametro queryParametro)
    {
        var result = await _getAllUsuarios.ExecuteAsync(queryParametro);
        
        return Ok(result);
    }
}