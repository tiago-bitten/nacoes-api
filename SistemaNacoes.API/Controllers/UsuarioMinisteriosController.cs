using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.UsuarioMinisterios.CriarUsuarioMinisterio;
using SistemaNacoes.Application.UseCases.UsuarioMinisterios.CriarUsuarioMinisterio.Dtos;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioMinisteriosController : ControllerBase
{
    #region Ctor
    private readonly ICriarUsuarioMinisterioUseCase _criar;
    
    public UsuarioMinisteriosController(ICriarUsuarioMinisterioUseCase criar)
    {
        _criar = criar;
    }
    #endregion
    
    #region Criar
    [HttpPost]
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CriarUsuarioMinisterioRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return Ok();
    }
    #endregion
}