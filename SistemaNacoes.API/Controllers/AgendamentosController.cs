using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Application.UseCases.Agendamentos;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgendamentosController : ControllerBase
{
    private readonly CreateAgendamento _createAgendamento;
    private readonly GetAllAgendamentos _getAllAgendamentos;
    private readonly DeleteAgendamento _deleteAgendamento;
    
    public AgendamentosController(CreateAgendamento createAgendamento, GetAllAgendamentos getAllAgendamentos, DeleteAgendamento deleteAgendamento)
    {
        _createAgendamento = createAgendamento;
        _getAllAgendamentos = getAllAgendamentos;
        _deleteAgendamento = deleteAgendamento;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CreateAgendamentoDto dto)
    {
        var result = await _createAgendamento.ExecuteAsync(dto);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] QueryParametro query)
    {
        var result = await _getAllAgendamentos.ExecuteAsync(query);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _deleteAgendamento.ExecuteAsync(id);
        return Ok(result);
    }
}