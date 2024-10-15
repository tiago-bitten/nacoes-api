using SistemaNacoes.Application.Dtos;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendas.ConcluirAgenda;

public class ConcluirAgenda : IConcluirAgendaUseCase
{
    private readonly IAgendaService _service;
    private readonly IUnitOfWork _uow;

    public ConcluirAgenda(IAgendaService service, IUnitOfWork uow)
    {
        _service = service;
        _uow = uow;
    }

    public async Task ExecutarAsync(int id)
    {
        var agenda = await _service.RecuperaGaranteExisteAsync(id);
        
        await _uow.IniciarTransacaoAsync();
        _service.Concluir(agenda);
        await _uow.CommitTransacaoAsync();
    }
}