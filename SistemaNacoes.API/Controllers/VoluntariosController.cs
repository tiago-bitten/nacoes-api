using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Voluntarios;
using SistemaNacoes.Application.UseCases.Voluntarios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VoluntariosController : ControllerBase
{
    private readonly CreateVoluntario _createVoluntario;

    public VoluntariosController(CreateVoluntario createVoluntario)
    {
        _createVoluntario = createVoluntario;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CreateVoluntarioDto dto)
    {
        var voluntarioDto = await _createVoluntario.ExecuteAsync(dto);
            
        return Ok(voluntarioDto);
    }
}