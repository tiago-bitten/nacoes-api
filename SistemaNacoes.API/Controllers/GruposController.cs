using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Controllers.Infra;
using SistemaNacoes.Application.UseCases.Grupos.CriarGrupo;
using SistemaNacoes.Application.UseCases.Grupos.CriarGrupo.Dtos;
using SistemaNacoes.Application.UseCases.Grupos.RemoverGrupo;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GruposController : ControllerNacoes
{
    #region Ctor
    private readonly ICriarGrupoUseCase _criar;
    private readonly IRemoverGrupoUseCase _remover;
    
    public GruposController(
        ICriarGrupoUseCase criar,
        IRemoverGrupoUseCase remover)
    {
        _criar = criar;
        _remover = remover;
    }
    #endregion
    
    #region Criar
    [HttpPost]
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CriarGrupoRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return RespostaSucesso(result, "Grupo criado com sucesso.");
    }
    #endregion
    
    #region Remover
    [HttpDelete("Remover/{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _remover.ExecutarAsync(id);
        return RespostaSucesso("Grupo removido com sucesso.");
    }
    #endregion
}