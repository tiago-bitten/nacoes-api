using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Agendas;
using SistemaNacoes.Application.UseCases.Agendas;

namespace SistemaNacoes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendasController : ControllerBase
    {
        private readonly OpenAgenda _openAgenda;
        private readonly CloseAgenda _closeAgenda;
        private readonly FinalizeAgenda _finalizeAgenda;

        public AgendasController(OpenAgenda openAgenda, FinalizeAgenda finalizeAgenda, CloseAgenda closeAgenda)
        {
            _openAgenda = openAgenda;
            _finalizeAgenda = finalizeAgenda;
            _closeAgenda = closeAgenda;
        }

        [HttpPost("Abrir")]
        public async Task<IActionResult> Open([FromBody] OpenAgendaDto dto)
        {
            var result = await _openAgenda.ExecuteAsync(dto);

            return Ok(result);
        }
        
        [HttpPut("Fechar")]
        public async Task<IActionResult> Close([FromBody] CloseAgendaDto dto)
        {
            var result = await _closeAgenda.ExecuteAsync(dto);

            return Ok(result);
        }

        [HttpPut("Finalizar")]
        public async Task<IActionResult> Finalize([FromBody] FinalizeAgendaDto dto)
        {
            var result = await _finalizeAgenda.ExecuteAsync(dto);

            return Ok(result);
        }
    }
}
