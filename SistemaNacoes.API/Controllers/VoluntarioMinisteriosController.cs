using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.CriarVoluntarioMinisterio;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.CriarVoluntarioMinisterio.Dtos;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.ListarVoluntarioMinisterio;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.RemoverVoluntarioMinisterio;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VoluntarioMinisteriosController : ControllerBase
{
    #region Ctor
    private readonly ICriarVoluntarioMinisterioUseCase _criar;
    private readonly IRemoverVoluntarioMinisterioUseCase _remover;
    private readonly IListarVoluntarioMinisterioUseCase _listar;
    
    public VoluntarioMinisteriosController(
        ICriarVoluntarioMinisterioUseCase criar,
        IRemoverVoluntarioMinisterioUseCase remover,
        IListarVoluntarioMinisterioUseCase listar)
    {
        _criar = criar;
        _remover = remover;
        _listar = listar;
    }

    #endregion
    
    #region Criar

    [HttpPost]
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CriarVoluntarioMinisterioRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return Ok();
    }
    #endregion
}