using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.Voluntarios.CriarVoluntario;
using SistemaNacoes.Application.UseCases.Voluntarios.CriarVoluntario.Dtos;
using SistemaNacoes.Application.UseCases.Voluntarios.ListarVoluntario;
using SistemaNacoes.Application.UseCases.Voluntarios.ListarVoluntario.Dtos;
using SistemaNacoes.Application.UseCases.Voluntarios.RemoverVoluntario;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VoluntariosController : ControllerBase
{
    #region Ctor
    private readonly ICriarVoluntarioUseCase _criar;
    private readonly IRemoverVoluntarioUseCase _remover;
    private readonly IListarVoluntarioUseCase _listar;
    
    public VoluntariosController(
        ICriarVoluntarioUseCase criar,
        IRemoverVoluntarioUseCase remover,
        IListarVoluntarioUseCase listar)
    {
        _criar = criar;
        _remover = remover;
        _listar = listar;
    }
    #endregion
    
    #region Criar
    [HttpPost]
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CriarVoluntarioRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return Ok();
    }
    #endregion
    
    #region Remover
    [HttpDelete("Remover/{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _remover.ExecutarAsync(id);
        return Ok();
    }
    #endregion
    
    #region Listar
    [HttpGet]
    [HttpGet("Listar")]
    public async Task<IActionResult> Listar([FromQuery] ListarVoluntarioParam param)
    {
        var result = await _listar.ExecutarAsync(param);
        return Ok();
    }
    #endregion
}