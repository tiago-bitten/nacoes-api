using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Voluntarios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Application.UseCases.Voluntarios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VoluntariosController : ControllerBase
{
    private readonly CreateVoluntario _createVoluntario;
    private readonly GetAllVoluntarios _getAllVoluntarios;
    private readonly DeleteVoluntario _deleteVoluntario;
    private readonly GetVoluntariosParaAgendar _getVoluntariosParaAgendar;

    public VoluntariosController(CreateVoluntario createVoluntario, GetAllVoluntarios getAllVoluntarios, DeleteVoluntario deleteVoluntario, GetVoluntariosParaAgendar getVoluntariosParaAgendar)
    {
        _createVoluntario = createVoluntario;
        _getAllVoluntarios = getAllVoluntarios;
        _deleteVoluntario = deleteVoluntario;
        _getVoluntariosParaAgendar = getVoluntariosParaAgendar;
    }
    
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CreateVoluntarioDto dto)
    {
        var result = await _createVoluntario.ExecuteAsync(dto);
            
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] QueryParametro query)
    {
        var result = await _getAllVoluntarios.ExecuteAsync(query);

        return Ok(result);
    }
    
    [HttpDelete("Deletar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _deleteVoluntario.ExecuteAsync(id);

        return Ok(result);
    }
    
    [HttpGet("BuscarParaAgendar/Agenda/{int:agendaId}/Ministerio/{int:ministerioId}")]
    public async Task<IActionResult> GetParaAgendar(int agendaId, int ministerioId)
    {
        var result = await _getVoluntariosParaAgendar.ExecuteAsync(agendaId, ministerioId);
        
        return Ok();
    }
}