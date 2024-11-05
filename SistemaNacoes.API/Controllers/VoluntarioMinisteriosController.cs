using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Controllers.Infra;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.CriarVoluntarioMinisterio;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.CriarVoluntarioMinisterio.Dtos;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.ListarVoluntarioMinisterio;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.ListarVoluntarioMinisterio.Dtos;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.RemoverVoluntarioMinisterio;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VoluntarioMinisteriosController : ControllerNacoes
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
        return RespostaSucesso(result, "Voluntário vinculado ao ministério com sucesso.");
    }
    #endregion
    
    #region Remover
    [HttpDelete("Remover/{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _remover.ExecutarAsync(id);
        return RespostaSucesso("Vínculo de voluntário com ministério removido com sucesso.");
    }
    #endregion
    
    #region Listar
    [HttpGet]
    [HttpGet("Listar")]
    public async Task<IActionResult> Listar([FromQuery] ListarVoluntarioMinisterioParam param)
    {
        var result = await _listar.ExecutarAsync(param);
        return RespostaPaginada(result, "Vínculos de voluntários com ministérios listados com sucesso.");
    }
    #endregion
}
