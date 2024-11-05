using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Controllers.Infra;
using SistemaNacoes.Application.UseCases.Ministerios.CriarMinisterio;
using SistemaNacoes.Application.UseCases.Ministerios.CriarMinisterio.Dtos;
using SistemaNacoes.Application.UseCases.Ministerios.RemoverMinisterio;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MinisteriosController : ControllerNacoes
{
    #region Ctor
    private readonly ICriarMinisterioUseCase _criar;
    private readonly IRemoverMinisterioUseCase _remover;
    
    public MinisteriosController(
        ICriarMinisterioUseCase criar,
        IRemoverMinisterioUseCase remover)
    {
        _criar = criar;
        _remover = remover;
    }
    #endregion
    
    #region Criar
    [HttpPost]
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CriarMinisterioRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return RespostaSucesso(result, "Ministério criado com sucesso.");
    } 
    #endregion
    
    #region Remover
    [HttpDelete("Remover/{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _remover.ExecutarAsync(id);
        return RespostaSucesso("Ministério removido com sucesso.");
    }
    #endregion
}