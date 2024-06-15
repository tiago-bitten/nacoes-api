using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.DTOs;
using SistemaNacoes.Application.UseCases.Usuarios;

namespace SistemaNacoes.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly CriarUsuario _criarUsuario;
        private readonly BuscarUsuarioPorId _buscarUsuarioPorId;

        public UsuariosController(CriarUsuario criarUsuario,
            BuscarUsuarioPorId buscarUsuarioPorId)
        {
            _criarUsuario = criarUsuario;
            _buscarUsuarioPorId = buscarUsuarioPorId;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarUsuarioDTO dto)
        {
            var usuario = await _criarUsuario.ExecuteAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _buscarUsuarioPorId.ExecuteAsync(id);
            return Ok(usuario);
        }
    }
}
