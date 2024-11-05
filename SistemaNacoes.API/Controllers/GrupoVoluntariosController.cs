using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Controllers.Infra;
using SistemaNacoes.Application.UseCases.GrupoVoluntarios.CriarGrupoVoluntario;
using SistemaNacoes.Application.UseCases.GrupoVoluntarios.CriarGrupoVoluntario.Dtos;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GrupoVoluntariosController : ControllerNacoes
{
    #region Ctor
    private readonly ICriarGrupoVoluntarioUseCase _criar;
    
    public GrupoVoluntariosController(ICriarGrupoVoluntarioUseCase criar)
    {
        _criar = criar;
    }
    #endregion
    
    #region Criar
    [HttpPost]
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CriarGrupoVoluntarioRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return RespostaSucesso(result, "Grupo de voluntário criado com sucesso.");
    }
    #endregion
}