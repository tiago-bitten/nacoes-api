using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Application.UseCases.Ministerios;
using SistemaNacoes.Application.UseCases.Voluntarios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MinisteriosController : ControllerBase
{
    private readonly CreateMinisterio _createMinisterio;
    private readonly GetAllMinisterios _getAllMinisterios;

    public MinisteriosController(CreateMinisterio createMinisterio, GetAllMinisterios getAllMinisterios)
    {
        _createMinisterio = createMinisterio;
        _getAllMinisterios = getAllMinisterios;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Create([FromBody] CreateMinisterioDto dto)
    {
        var result = await _createMinisterio.ExecuteAsync(dto);

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] QueryParametro query)
    {
        var result = await _getAllMinisterios.ExecuteAsync(query);

        return Ok(result);
    }
}