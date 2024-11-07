using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Attributes;

namespace SistemaNacoes.API.Controllers.Infra;

[NacoesAuth]
[Route("api/[controller]")]
public class AdminController : ControllerNacoes
{
    [HttpPost("LogarComUsuario")]
    public async Task<IActionResult> RecuperarUsuarioAdm([FromBody])
    
}