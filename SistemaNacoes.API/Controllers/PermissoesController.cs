using Microsoft.AspNetCore.Authorization;
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
    private readonly GetUsuarioPermissoes _getUsuarioPermissoes;

    public PermissoesController(GetAllPermissoes getAllPermissoes, RemoveUsuarioPermissoes removeUsuarioPermissoes,
        GetUsuarioPermissoes getUsuarioPermissoes)
    {
        _getAllPermissoes = getAllPermissoes;
        _removeUsuarioPermissoes = removeUsuarioPermissoes;
        _getUsuarioPermissoes = getUsuarioPermissoes;
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

    [Authorize]
    [HttpGet("Usuario")]
    public async Task<IActionResult> GetUsuarioPermissoes()
    {
        var result = await _getUsuarioPermissoes.ExecuteAsync();

        return Ok(result);
    }
}