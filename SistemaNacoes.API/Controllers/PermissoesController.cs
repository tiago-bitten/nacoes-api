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
    private readonly RemovePermissoesUsuario _removePermissoesUsuario;
    private readonly GetPermissoesUsuario _getPermissoesUsuario;
    private readonly AddPermissoesUsuario _addPermissoesUsuario;

    public PermissoesController(GetAllPermissoes getAllPermissoes, RemovePermissoesUsuario removePermissoesUsuario,
        GetPermissoesUsuario getPermissoesUsuario, AddPermissoesUsuario addPermissoesUsuario)
    {
        _getAllPermissoes = getAllPermissoes;
        _removePermissoesUsuario = removePermissoesUsuario;
        _getPermissoesUsuario = getPermissoesUsuario;
        _addPermissoesUsuario = addPermissoesUsuario;
    }

    [HttpGet]
    public IActionResult GetPermissoes()
    {
        var result = _getAllPermissoes.Execute();

        return Ok(result);
    }

    [HttpPut("Remover")]
    public async Task<IActionResult> RemoveUsuarioPermissoes([FromBody] RemoveUsuarioPermissoesDto dto)
    {
        var result = await _removePermissoesUsuario.ExecuteAsync(dto);

        return Ok(result);
    }
    
    [HttpPut("Adicionar")]
    public async Task<IActionResult> AddPermissoesUsuario([FromBody] AddPermissoesUsuarioDto dto)
    {
        var result = await _addPermissoesUsuario.ExecuteAsync(dto);

        return Ok(result);
    }

    [Authorize]
    [HttpGet("Usuario")]
    public async Task<IActionResult> GetUsuarioPermissoes()
    {
        var result = await _getPermissoesUsuario.ExecuteAsync();

        return Ok(result);
    }
}