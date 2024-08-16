using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.DataIndisponiveis;
using SistemaNacoes.Application.UseCases.DataIndisponiveis;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataIndisponiveisController : ControllerBase
{
    private readonly CreateDataIndisponivel _createDataIndisponivel;
    private readonly GetAllDataIndisponiveis _getAllDataIndisponiveis;
    private readonly SuspendDataIndisponivel _suspendDataIndisponivel;

    public DataIndisponiveisController(CreateDataIndisponivel createDataIndisponivel, GetAllDataIndisponiveis getAllDataIndisponiveis, SuspendDataIndisponivel suspendDataIndisponivel)
    {
        _createDataIndisponivel = createDataIndisponivel;
        _getAllDataIndisponiveis = getAllDataIndisponiveis;
        _suspendDataIndisponivel = suspendDataIndisponivel;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Create([FromBody] CreateDataIndisponivelDto dto)
    {
        var result = await _createDataIndisponivel.ExecuteAsync(dto);

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllDataIndisponiveis.ExecuteAsync();

        return Ok(result);
    }
    
    [HttpPut("Suspender/{id}")]
    public async Task<IActionResult> Suspend(int id)
    {
        var result = await _suspendDataIndisponivel.ExecuteAsync(id);

        return Ok(result);
    }
    
    // [HttpDelete("Remover/{id}")]
}