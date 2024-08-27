using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.Permissoes;
using SistemaNacoes.Application.UseCases.UsuarioMinisterios;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AmbienteController : ControllerBase
{
    private readonly GetUsuarioPermissoes _getUsuarioPermissoes;
    private readonly GetUsuarioMinisterios _getUsuarioMinisterios;

    public AmbienteController(GetUsuarioPermissoes getUsuarioPermissoes, GetUsuarioMinisterios getUsuarioMinisterios)
    {
        _getUsuarioPermissoes = getUsuarioPermissoes;
        _getUsuarioMinisterios = getUsuarioMinisterios;
    }

    [HttpGet("UsuarioPermissoes")]
    public async Task<IActionResult> GetPermissoesUsuario()
    {
        var result = await _getUsuarioPermissoes.ExecuteAsync();
        
        return Ok(result);
    }
    
    [HttpGet("UsuarioMinisterios")]
    public async Task<IActionResult> GetMinisteriosUsuario()
    {
        var result = await _getUsuarioMinisterios.ExecuteAsync();
        
        return Ok(result);
    }
}