using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.Permissoes;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AmbienteController : ControllerBase
{
    private readonly GetUsuarioPermissoes _getUsuarioPermissoes;

    public AmbienteController(GetUsuarioPermissoes getUsuarioPermissoes)
    {
        _getUsuarioPermissoes = getUsuarioPermissoes;
    }

    public async Task<IActionResult> GetPermissoesUsuario()
    {
        var result = await _getUsuarioPermissoes.ExecuteAsync();
        
        return Ok(result);
    }
}