using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgendamentosController : ControllerBase
{
    #region Ctor
    private readonly ICriarAgendamentoUseCase _criar;

    public AgendamentosController(ICriarAgendamentoUseCase criar)
    {
        _criar = criar;
    }
    #endregion

    [HttpPost]
    public async Task<IActionResult> Criar(CriarAgendamentoRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return Ok(result);
    }
}