using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Application.UseCases.Agendas.AbrirAgenda;
using SistemaNacoes.Application.UseCases.Agendas.AbrirAgenda.Dtos;
using SistemaNacoes.Application.UseCases.Agendas.ConcluirAgenda;
using SistemaNacoes.Application.UseCases.Agendas.ListarAgenda;
using SistemaNacoes.Application.UseCases.Agendas.RemoverAgenda;

namespace SistemaNacoes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgendasController : ControllerBase
{
    #region Ctor
    private readonly IAbrirAgendaUseCase _abrir;
    private readonly IRemoverAgendaUseCase _remover;
    private readonly IConcluirAgendaUseCase _concluir;
    private readonly IListarAgendaUseCase _listar;

    public AgendasController(IAbrirAgendaUseCase abrir, IRemoverAgendaUseCase remover, IConcluirAgendaUseCase concluir, IListarAgendaUseCase listar)
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
        return Ok();
    }
    #endregion
}