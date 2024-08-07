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

    public MinisteriosController(CreateMinisterio createMinisterio)
    {
        _createMinisterio = createMinisterio;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Create([FromBody] CreateMinisterioDto dto)
    {
        var result = await _createMinisterio.ExecuteAsync(dto);

        return Ok(result);
    }
}