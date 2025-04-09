using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Attributes;
using SistemaNacoes.Application.UseCases.Adm.LogarComUsuario.Dtos;

namespace SistemaNacoes.API.Controllers.Infra;

[NacoesAuth]
[Route("api/[controller]")]
public class AdminController : ControllerNacoes
{
    [HttpPost("LogarComUsuario")]
    public async Task<IActionResult> RecuperarUsuarioAdm([FromBody] LogarComUsuarioRequest request)
    {
        throw new NotImplementedException();
    }
    
}