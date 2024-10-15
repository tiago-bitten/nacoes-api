using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Application.UseCases.Agendamentos;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;
using SistemaNacoes.Application.UseCases.Agendamentos.RemoverAgendamento;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgendamentosController : ControllerBase
{
    private readonly ICriarAgendamentoUseCase _criarUseCase;
    private readonly GetAllAgendamentos _getAllAgendamentos;
    private readonly RemoverAgendamento _deleteAgendamento;
    private readonly VinculateAgendamentoAtividade _vinculateAgendamentoAtividade;
    private readonly DeleteAgendamentoAtividade _deleteAgendamentoAtividade;
    
    public AgendamentosController(ICriarAgendamentoUseCase createAgendamento, GetAllAgendamentos getAllAgendamentos, RemoverAgendamento deleteAgendamento, VinculateAgendamentoAtividade vinculateAgendamentoAtividade, DeleteAgendamentoAtividade deleteAgendamentoAtividade)
    {
        _criarUseCase = createAgendamento;
        _getAllAgendamentos = getAllAgendamentos;
        _deleteAgendamento = deleteAgendamento;
        _vinculateAgendamentoAtividade = vinculateAgendamentoAtividade;
        _deleteAgendamentoAtividade = deleteAgendamentoAtividade;
    }
    
    [Authorize]
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CriarAgendamentoRequest dto)
    {
        var result = await _criarUseCase.ExecutarAsync(dto);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] QueryParametro query)
    {
        var result = await _getAllAgendamentos.ExecuteAsync(query);
        return Ok(result);
    }
    
    [HttpDelete("Deletar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _deleteAgendamento.ExecuteAsync(id);
        return Ok(result);
    }
    
    [HttpPost("VincularAtividade")]
    public async Task<IActionResult> VinculateAtividadeAgendamento([FromBody] VinculateAgendamentoAtividadeDto dto)
    {
        var result = await _vinculateAgendamentoAtividade.ExecuteAsync(dto);
        
        return Ok(result);
    }
    
    [HttpDelete("DesvincularAtividade/{agendamentoId}/{atividadeId}")]
    public async Task<IActionResult> DeleteAgendamentoAtividade(int agendamentoId, int atividadeId)
    {
        var result = await _deleteAgendamentoAtividade.ExecuteAsync(agendamentoId, atividadeId);
        
        return Ok(result);
    }
}