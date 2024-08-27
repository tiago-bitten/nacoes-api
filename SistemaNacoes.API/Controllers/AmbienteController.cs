using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.Permissoes;
using SistemaNacoes.Application.UseCases.UsuarioMinisterios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AmbienteController : ControllerBase
{
    private readonly GetPermissoesUsuario _getPermissoesUsuario;
    private readonly GetUsuarioMinisterios _getUsuarioMinisterios;

    public AmbienteController(GetPermissoesUsuario getPermissoesUsuario, GetUsuarioMinisterios getUsuarioMinisterios)
    {
        _getPermissoesUsuario = getPermissoesUsuario;
        _getUsuarioMinisterios = getUsuarioMinisterios;
    }

    [HttpGet("UsuarioPermissoes")]
    public async Task<IActionResult> GetPermissoesUsuario()
    {
        var result = await _getPermissoesUsuario.ExecuteAsync();
        
        return Ok(result);
    }
    
    [HttpGet("UsuarioMinisterios")]
    public async Task<IActionResult> GetMinisteriosUsuario()
    {
        var result = await _getUsuarioMinisterios.ExecuteAsync();
        
        return Ok(result);
    }
}