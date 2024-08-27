using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.UsuarioMinisterios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Application.UseCases.UsuarioMinisterios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioMinisteriosController : ControllerBase
{
    private readonly VinculateUsuarioMinisterio _vinculateUsuarioMinisterio;
    private readonly GetAllUsuarioMinisterios _getAllUsuarioMinisterios;

    public UsuarioMinisteriosController(VinculateUsuarioMinisterio vinculateUsuarioMinisterio, GetAllUsuarioMinisterios getAllUsuarioMinisterios)
    {
        _vinculateUsuarioMinisterio = vinculateUsuarioMinisterio;
        _getAllUsuarioMinisterios = getAllUsuarioMinisterios;
    }
    
    [HttpPost("Vincular")]
    public async Task<IActionResult> Vinculate([FromBody] VinculateUsuarioMinisterioDto dto)
    {
        var result = await _vinculateUsuarioMinisterio.ExecuteAsync(dto);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParametro queryParametro)
    {
        var result = await _getAllUsuarioMinisterios.ExcecuteAsync(queryParametro);
        
        return Ok(result);
    }
}