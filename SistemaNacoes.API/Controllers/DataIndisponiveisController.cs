using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.DataIndisponiveis;
using SistemaNacoes.Application.UseCases.DataIndisponiveis;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataIndisponiveisController : ControllerBase
{
    private readonly CreateDataIndisponivel _createDataIndisponivel;

    public DataIndisponiveisController(CreateDataIndisponivel createDataIndisponivel)
    {
        _createDataIndisponivel = createDataIndisponivel;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Create([FromBody] CreateDataIndisponivelDto dto)
    {
        var result = await _createDataIndisponivel.ExecuteAsync(dto);

        return Ok(result);
    }
}