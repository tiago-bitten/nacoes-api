using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Controllers.Infra;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;
using SistemaNacoes.Application.UseCases.Agendamentos.RemoverAgendamento;

namespace SistemaNacoes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgendamentosController : ControllerNacoes
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
    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] CriarAgendamentoRequest request)
    {
        var result = await _criar.ExecutarAsync(request);
        return RespostaSucesso(result, "Agendamento criado com sucesso.");
    }
    #endregion
    
    #region Remover
    [HttpDelete("{id:int}")]
    [HttpDelete("Remover/{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _remover.ExecutarAsync(id);
        return RespostaSucesso("Agendamento removido com sucesso.");
    }
    #endregion
}