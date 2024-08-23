using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.GrupoVoluntarios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GrupoVoluntariosController : ControllerBase
{
    private readonly GetVoluntariosNoGrupo _getVoluntariosNoGrupo;

    public GrupoVoluntariosController(GetVoluntariosNoGrupo getVoluntariosNoGrupo)
    {
        _getVoluntariosNoGrupo = getVoluntariosNoGrupo;
    }
    
    [HttpGet("VoluntariosNoGrupo/{grupoId}")]
    public async Task<IActionResult> GetVoluntariosNoGrupo(int grupoId)
    {
        var result = await _getVoluntariosNoGrupo.ExecuteAsync(grupoId);
        return Ok(result);
    }
}