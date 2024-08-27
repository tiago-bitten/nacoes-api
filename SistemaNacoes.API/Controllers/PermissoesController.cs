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
    private readonly AddPermissoesUsuario _addPermissoesUsuario;

    public PermissoesController(GetAllPermissoes getAllPermissoes, RemoveUsuarioPermissoes removeUsuarioPermissoes,
        GetUsuarioPermissoes getUsuarioPermissoes, AddPermissoesUsuario addPermissoesUsuario)
    {
        _getAllPermissoes = getAllPermissoes;
        _removeUsuarioPermissoes = removeUsuarioPermissoes;
        _getUsuarioPermissoes = getUsuarioPermissoes;
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
        var result = await _removeUsuarioPermissoes.ExecuteAsync(dto);

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
        var result = await _getUsuarioPermissoes.ExecuteAsync();

        return Ok(result);
    }
}