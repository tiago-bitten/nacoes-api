using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.DTOs;
using SistemaNacoes.Application.UseCases.Usuarios;

namespace SistemaNacoes.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly CriarUsuario _criarUsuario;

        public UsuarioController(CriarUsuario criarUsuario)
        {
            _criarUsuario = criarUsuario;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarUsuarioDTO dto)
        {
            try
            {
                var usuario = await _criarUsuario.ExecuteAsync(dto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
