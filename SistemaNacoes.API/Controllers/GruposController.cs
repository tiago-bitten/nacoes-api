using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Application.UseCases.Grupos;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GruposController : ControllerBase
{
    #region dp
    private readonly CreateGrupo _createGrupo;
    private readonly DeleteGrupo _deleteGrupo;
    private readonly GetAllGrupos _getAllGrupos;
    #endregion
    
    #region ctor
    public GruposController(CreateGrupo createGrupo, DeleteGrupo deleteGrupo, GetAllGrupos getAllGrupos)
    {
        _createGrupo = createGrupo;
        _deleteGrupo = deleteGrupo;
        _getAllGrupos = getAllGrupos;
    }
    #endregion
    
    #region Criar Grupo
    [HttpPost("Criar")]
    public async Task<IActionResult> Create([FromBody] CreateGrupoDto createGrupoDto)
    {
        var result = await _createGrupo.ExecuteAsync(createGrupoDto);
        
        return Ok(result);
    }
    #endregion
    
    #region Deletar Grupo
    [HttpDelete("Deletar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _deleteGrupo.ExecuteAsync(id);
        
        return Ok(result);
    }
    #endregion
    
    #region Listar Grupos
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParametro query)
    {
        var result = await _getAllGrupos.ExecuteAsync(query);
        
        return Ok(result);
    }
    #endregion
}