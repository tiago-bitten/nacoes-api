using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Controllers.Infra;
using SistemaNacoes.Application.UseCases.DataIndisponiveis.CriarDataIndisponivel;
using SistemaNacoes.Application.UseCases.DataIndisponiveis.CriarDataIndisponivel.Dtos;
using SistemaNacoes.Application.UseCases.DataIndisponiveis.RemoverDataIndisponivel;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataIndisponiveisController : ControllerNacoes
{
    #region Ctor
    private readonly ICriarDataIndisponivelUseCase _criar;
    private readonly IRemoverDataIndisponivelUseCase _remover;
    
    public DataIndisponiveisController(
        ICriarDataIndisponivelUseCase criar,
        IRemoverDataIndisponivelUseCase remover)
    {
        _criar = criar;
        _remover = remover;
    }
    #endregion
    
    #region Criar
    [HttpPost]
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CriarDataIndisponivelRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return RespostaSucesso(result, "Data indisponível criada com sucesso.");
    }
    #endregion
    
    #region Remover
    [HttpDelete("Remover/{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _remover.ExecutarAsync(id);
        return RespostaSucesso("Data indisponível removida com sucesso.");
    }
    #endregion
}