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
    private readonly GetAllVoluntarios _getAllVoluntarios;

    public MinisteriosController(CreateMinisterio createMinisterio, GetAllVoluntarios getAllVoluntarios)
    {
        _createMinisterio = createMinisterio;
        _getAllVoluntarios = getAllVoluntarios;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Create([FromBody] CreateMinisterioDto dto)
    {
        var result = await _createMinisterio.ExecuteAsync(dto);

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParametro query)
    {
        var result = await _getAllVoluntarios.ExecuteAsync(query);

        return Ok(result);
    }
}