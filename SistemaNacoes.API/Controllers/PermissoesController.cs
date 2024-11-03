using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.Permissoes.AdicionarPermissao;
using SistemaNacoes.Application.UseCases.Permissoes.AdicionarPermissao.Dtos;
using SistemaNacoes.Application.UseCases.Permissoes.ListarPermissoes;
using SistemaNacoes.Application.UseCases.Permissoes.ListarPermissoes.Dtos;
using SistemaNacoes.Application.UseCases.Permissoes.RemoverPermissao;
using SistemaNacoes.Application.UseCases.Permissoes.RemoverPermissao.Dtos;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissoesController : ControllerBase
{
    #region Ctor
    private readonly IAdicionarPermissaoUseCase _adicionar;
    private readonly IRemoverPermissaoUseCase _remover;
    private readonly IListarPermissoesUseCase _listar;
    
    public PermissoesController(
        IAdicionarPermissaoUseCase adicionar,
        IRemoverPermissaoUseCase remover,
        IListarPermissoesUseCase listar)
    {
        _adicionar = adicionar;
        _remover = remover;
        _listar = listar;
    }
    #endregion
    
    #region Adicionar
    [HttpPost("Adicionar")]
    public async Task<IActionResult> Adicionar([FromBody] AdicionarPermissaoRequest request)
    {
        await _adicionar.ExecutarAsync(request);
        return Ok();
    }
    #endregion
    
    #region Remover
    [HttpPut("Remover")]
    public async Task<IActionResult> Remover([FromBody] RemoverPermissaoRequest request)
    {
        await _remover.ExecutarAsync(request);
        return Ok();
    }
    #endregion
    
    #region Listar
    [HttpGet]
    [HttpGet("Listar")]
    public async Task<IActionResult> Listar([FromQuery] ListarPermissoesParam param)
    {
        var result = await _listar.ExecutarAsync(param);
        return Ok();
    }
    #endregion
}