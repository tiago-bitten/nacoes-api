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

        public AgendasController(OpenAgenda openAgenda)
        {
            _openAgenda = openAgenda;
        }

        [HttpPost("Abrir")]
        public async Task<IActionResult> AbrirAgenda([FromBody] OpenAgendaDto dto)
        {
            var result = await _openAgenda.ExecuteAsync(dto);

            return Ok(result);
        }
    }
}
