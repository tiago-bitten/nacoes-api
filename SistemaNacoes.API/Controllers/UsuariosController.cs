using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Controllers.Infra;
using SistemaNacoes.Application.UseCases.Usuarios.CriarUsuario;
using SistemaNacoes.Application.UseCases.Usuarios.CriarUsuario.Dtos;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerNacoes
{
    #region Ctor
    private readonly ICriarUsuarioUseCase _criar;
    
    public UsuariosController(ICriarUsuarioUseCase criar)
    {
        _criar = criar;
    }
    #endregion
    
    #region Criar
    [HttpPost]
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CriarUsuarioRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return RespostaSucesso(result, "Usuário criado com sucesso.");
    }
    #endregion
}