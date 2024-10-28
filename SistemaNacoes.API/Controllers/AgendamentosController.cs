using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;
using SistemaNacoes.Application.UseCases.Agendamentos.RemoverAgendamento;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgendamentosController : ControllerBase
{
    #region Ctor
    private readonly ICriarAgendamentoUseCase _criar;
    private readonly IRemoverAgendamentoUseCase _remover;

    public AgendamentosController(
        ICriarAgendamentoUseCase criar, 
        IRemoverAgendamentoUseCase remover)
    {
        _criar = criar;
        _remover = remover;
    }
    #endregion

    #region Criar
    [HttpPost]
    public async Task<IActionResult> Criar(CriarAgendamentoRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return Ok(result);
    }
    #endregion
    
    #region Remover
    [HttpDelete("{id}")]
    [HttpDelete("Remover/{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _remover.ExecutarAsync(id);
        return Ok();
    }
    #endregion
}