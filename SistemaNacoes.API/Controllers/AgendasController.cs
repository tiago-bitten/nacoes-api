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
        private readonly RemoveAgenda _removeAgenda;
        private readonly FinalizeAgenda _finalizeAgenda;
        private readonly GetAllAgendas _getAllAgendas;

        public AgendasController(OpenAgenda openAgenda, FinalizeAgenda finalizeAgenda, RemoveAgenda removeAgenda, GetAllAgendas getAllAgendas)
        {
            _openAgenda = openAgenda;
            _finalizeAgenda = finalizeAgenda;
            _removeAgenda = removeAgenda;
            _getAllAgendas = getAllAgendas;
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
            var result = await _removeAgenda.ExecuteAsync(dto);

            return Ok(result);
        }

        [HttpPut("Finalizar")]
        public async Task<IActionResult> Finalize([FromBody] FinalizeAgendaDto dto)
        {
            var result = await _finalizeAgenda.ExecuteAsync(dto);

            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int mes, int ano)
        {
            var result = await _getAllAgendas.ExecuteAsync(mes, ano);

            return Ok(result);
        }
    }
}
