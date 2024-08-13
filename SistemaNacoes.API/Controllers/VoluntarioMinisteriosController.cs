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
    private readonly DesvinculateVoluntarioMinisterio _desvinculateVoluntarioMinisterio;

    public VoluntarioMinisteriosController(
        GetAllVoluntarioMinisterios getAllVoluntarioMinisterios,
        VinculateVoluntarioMinisterio vinculateVoluntarioMinisterio, 
        DesvinculateVoluntarioMinisterio desvinculateVoluntarioMinisterio)
    {
        _getAllVoluntarioMinisterios = getAllVoluntarioMinisterios;
        _vinculateVoluntarioMinisterio = vinculateVoluntarioMinisterio;
        _desvinculateVoluntarioMinisterio = desvinculateVoluntarioMinisterio;
    }
    
    [HttpPost("Vincular")]
    public async Task<IActionResult> Vincular([FromBody] VinculateVoluntarioMinisterioDto dto)
    {
        var result = await _vinculateVoluntarioMinisterio.ExecuteAsync(dto);
        
        return Ok(result);
    }
    
    [HttpPut("Desvincular")]
    public async Task<IActionResult> Desvincular([FromQuery] int voluntarioId, int ministerioId)
    {
        var result = await _desvinculateVoluntarioMinisterio.ExecuteAsync(voluntarioId, ministerioId);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParametro query)
    {
        var result = await _getAllVoluntarioMinisterios.ExecuteAsync(query);
        
        return Ok(result);
    }
}