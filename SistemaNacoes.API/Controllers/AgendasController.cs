using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.API.Controllers.Infra;
using SistemaNacoes.Application.UseCases.Agendas.AbrirAgenda;
using SistemaNacoes.Application.UseCases.Agendas.AbrirAgenda.Dtos;
using SistemaNacoes.Application.UseCases.Agendas.ConcluirAgenda;
using SistemaNacoes.Application.UseCases.Agendas.ListarAgenda;
using SistemaNacoes.Application.UseCases.Agendas.ListarAgenda.Dto;
using SistemaNacoes.Application.UseCases.Agendas.RemoverAgenda;

namespace SistemaNacoes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgendasController : ControllerNacoes
{
    #region Ctor
    private readonly IAbrirAgendaUseCase _abrir;
    private readonly IRemoverAgendaUseCase _remover;
    private readonly IConcluirAgendaUseCase _concluir;
    private readonly IListarAgendaUseCase _listar;

    public AgendasController(
        IAbrirAgendaUseCase abrir, 
        IRemoverAgendaUseCase remover, 
        IConcluirAgendaUseCase concluir, 
        IListarAgendaUseCase listar)
    {
        _abrir = abrir;
        _remover = remover;
        _concluir = concluir;
        _listar = listar;
    }
    #endregion

    #region Abrir
    [HttpPost("Abrir")]
    public async Task<IActionResult> Abrir([FromBody] AbrirAgendaRequest request)
    {
        var result = await _abrir.ExecutarAsync(request);
        return RespostaSucesso(result, "Agenda aberta com sucesso.");
    }
    #endregion

    #region Remover
    [HttpDelete("Remover/{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _remover.ExecutarAsync(id);
        return RespostaSucesso("Agenda removida com sucesso.");
    }
    #endregion

    #region Concluir
    [HttpPost("Concluir/{id:int}")]
    public async Task<IActionResult> Concluir(int id)
    {
        await _concluir.ExecutarAsync(id);
        return RespostaSucesso("Agenda concluída com sucesso.");
    }
    #endregion

    #region Listar
    [HttpGet("Listar")]
    public async Task<IActionResult> Listar([FromQuery] ListarAgendaParams param)
    {
        var result = await _listar.ExecutarAsync(param);
        return RespostaPaginada(result, "Agendas listadas com sucesso.");
    }
    #endregion
}
