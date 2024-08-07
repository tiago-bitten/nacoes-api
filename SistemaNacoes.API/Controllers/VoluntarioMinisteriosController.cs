using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.VoluntarioMinisterios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VoluntarioMinisteriosController : ControllerBase
{
    private readonly GetAllVoluntarioMinisterios _getAllVoluntarioMinisterios;
    private readonly VinculateVoluntarioMinisterio _vinculateVoluntarioMinisterio;

    public VoluntarioMinisteriosController(
        GetAllVoluntarioMinisterios getAllVoluntarioMinisterios,
        VinculateVoluntarioMinisterio vinculateVoluntarioMinisterio)
    {
        _getAllVoluntarioMinisterios = getAllVoluntarioMinisterios;
        _vinculateVoluntarioMinisterio = vinculateVoluntarioMinisterio;
    }
    
    [HttpPost("Vincular")]
    public async Task<IActionResult> Vincular([FromBody] VinculateVoluntarioMinisterioDto dto)
    {
        var result = await _vinculateVoluntarioMinisterio.ExecuteAsync(dto);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParametro query)
    {
        var result = await _getAllVoluntarioMinisterios.ExecuteAsync(query);
        
        return Ok(result);
    }
}