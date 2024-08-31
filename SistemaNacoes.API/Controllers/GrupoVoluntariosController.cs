using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.UseCases.Grupos;
using SistemaNacoes.Application.UseCases.GrupoVoluntarios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GrupoVoluntariosController : ControllerBase
{
    #region dp
    private readonly VinculateVoluntarioGrupo _vinculateVoluntarioGrupo;
    private readonly GetVoluntariosNoGrupo _getVoluntariosNoGrupo;
    #endregion
    
    #region ctor
    public GrupoVoluntariosController(GetVoluntariosNoGrupo getVoluntariosNoGrupo, VinculateVoluntarioGrupo vinculateVoluntarioGrupo)
    {
        _getVoluntariosNoGrupo = getVoluntariosNoGrupo;
        _vinculateVoluntarioGrupo = vinculateVoluntarioGrupo;
    }
    #endregion

    #region vincular voluntario no grupo
    [HttpPost("VincularVoluntario")]
    public async Task<IActionResult> VinculateGrupoVoluntario(VinculateVoluntarioGrupoDto dto)
    {
        var result = await _vinculateVoluntarioGrupo.ExecuteAsync(dto);

        return Ok(result);
    }
    #endregion 
    
    #region listar voluntarios em determinado grupo
    [HttpGet("VoluntariosNoGrupo/{grupoId}")]
    public async Task<IActionResult> GetVoluntariosNoGrupo(int grupoId)
    {
        var result = await _getVoluntariosNoGrupo.ExecuteAsync(grupoId);
        return Ok(result);
    }
    #endregion
}