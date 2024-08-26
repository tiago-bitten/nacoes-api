using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.Dtos.Permissoes;
using SistemaNacoes.Application.UseCases.Permissoes;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissoesController : ControllerBase
{
    private readonly GetAllPermissoes _getAllPermissoes;
    private readonly RemoveUsuarioPermissoes _removeUsuarioPermissoes;

    public PermissoesController(GetAllPermissoes getAllPermissoes, RemoveUsuarioPermissoes removeUsuarioPermissoes)
    {
        _getAllPermissoes = getAllPermissoes;
        _removeUsuarioPermissoes = removeUsuarioPermissoes;
    }

    [HttpGet]
    public IActionResult GetPermissoes()
    {
        var result = _getAllPermissoes.Execute();
        
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> RemoveUsuarioPermissoes([FromBody] RemoveUsuarioPermissoesDto dto)
    {
        var result = await _removeUsuarioPermissoes.ExecuteAsync(dto);
        
        return Ok(result);
    }
}