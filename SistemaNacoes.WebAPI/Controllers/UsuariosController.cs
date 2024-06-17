using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.DTOs;
using SistemaNacoes.Application.UseCases.Usuarios;

namespace SistemaNacoes.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly LoginUsuario _loginUsuario;
        private readonly CriarUsuario _criarUsuario;
        private readonly ObterUsuarioPorId _obterUsuarioPorId;

        public UsuariosController(LoginUsuario loginUsuario, 
            CriarUsuario criarUsuario,
            ObterUsuarioPorId obterUsuarioPorId)
        {
            _loginUsuario = loginUsuario;
            _criarUsuario = criarUsuario;
            _obterUsuarioPorId = obterUsuarioPorId;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Criar([FromBody] LoginDTO dto)
        {
            var token = await _loginUsuario.ExecuteAsync(dto);
            return Ok(token);
        }

        [HttpPost("Criar")]
        [Authorize]
        public async Task<IActionResult> Criar([FromBody] CriarUsuarioDTO dto)
        {
            var usuarioDTO = await _criarUsuario.ExecuteAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = usuarioDTO.Id }, usuarioDTO);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var usuario = await _obterUsuarioPorId.ExecuteAsync(id);
            return Ok(usuario);
        }
    }
}
