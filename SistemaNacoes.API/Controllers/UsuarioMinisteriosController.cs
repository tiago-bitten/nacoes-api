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
    private readonly GetUsuarioMinisterios _getUsuarioMinisterios;

    public UsuarioMinisteriosController(VinculateUsuarioMinisterio vinculateUsuarioMinisterio, GetAllUsuarioMinisterios getAllUsuarioMinisterios, GetUsuarioMinisterios getUsuarioMinisterios)
    {
        _vinculateUsuarioMinisterio = vinculateUsuarioMinisterio;
        _getAllUsuarioMinisterios = getAllUsuarioMinisterios;
        _getUsuarioMinisterios = getUsuarioMinisterios;
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
    
    [HttpGet("Usuario")]
    public async Task<IActionResult> GetUsuarioMinisterios()
    {
        var result = await _getUsuarioMinisterios.ExecuteAsync();
        
        return Ok(result);
    }
}