﻿using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Application.UseCases.Grupos;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GruposController : ControllerBase
{
    private readonly CreateGrupo _createGrupo;
    private readonly DeleteGrupo _deleteGrupo;
    private readonly GetAllGrupos _getAllGrupos;
    private readonly VinculateVoluntarioGrupo _vinculateVoluntarioGrupo;
    
    public GruposController(CreateGrupo createGrupo, DeleteGrupo deleteGrupo, GetAllGrupos getAllGrupos, VinculateVoluntarioGrupo vinculateVoluntarioGrupo)
    {
        _createGrupo = createGrupo;
        _deleteGrupo = deleteGrupo;
        _getAllGrupos = getAllGrupos;
        _vinculateVoluntarioGrupo = vinculateVoluntarioGrupo;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Create([FromBody] CreateGrupoDto createGrupoDto)
    {
        var result = await _createGrupo.ExecuteAsync(createGrupoDto);
        
        return Ok(result);
    }
    
    [HttpDelete("Deletar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _deleteGrupo.ExecuteAsync(id);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParametro query)
    {
        var result = await _getAllGrupos.ExecuteAsync(query);
        
        return Ok(result);
    }
    
    [HttpPost("VinicularVoluntario")]
    public async Task<IActionResult> VinculateVoluntarioGrupo([FromBody] VinculateVoluntarioGrupoDto vinculateVoluntarioGrupoDto)
    {
        var result = await _vinculateVoluntarioGrupo.ExecuteAsync(vinculateVoluntarioGrupoDto);
        
        return Ok(result);
    }
}