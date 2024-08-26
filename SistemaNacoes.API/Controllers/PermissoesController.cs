using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.Permissoes;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissoesController : ControllerBase
{
    private readonly GetAllPermissoes _getAllPermissoes;

    public PermissoesController(GetAllPermissoes getAllPermissoes)
    {
        _getAllPermissoes = getAllPermissoes;
    }

    [HttpGet]
    public IActionResult GetPermissoes()
    {
        var result = _getAllPermissoes.Execute();
        
        return Ok(result);
    }
}