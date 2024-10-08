﻿using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Atividades;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Application.UseCases.Atividades;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AtividadesController : ControllerBase
{
    private readonly CreateAtividade _createAtividade;
    private readonly GetAllAtividades _getAllAtividades;
    private readonly DeleteAtividade _deleteAtividade;

    public AtividadesController(CreateAtividade createAtividade, GetAllAtividades getAllAtividades, DeleteAtividade deleteAtividade)
    {
        _createAtividade = createAtividade;
        _getAllAtividades = getAllAtividades;
        _deleteAtividade = deleteAtividade;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Create([FromBody] CreateAtividadeDto dto)
    {
        var result = await _createAtividade.ExecuteAsync(dto);

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParametro query)
    {
        var result = await _getAllAtividades.ExecuteAsync(query);

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _deleteAtividade.ExecuteAsync(id);

        return Ok(result);
    }
}