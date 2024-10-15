using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendas.RemoverAgenda;

public class RemoverAgenda : IRemoverAgendaUseCase
{
    private readonly IAgendaService _service;
    private readonly IUnitOfWork _uow;

    public RemoverAgenda(IAgendaService service, IUnitOfWork uow)
    {
        _service = service;
        _uow = uow;
    }

    public async Task ExecutarAsync(int id)
    {
        var agenda = await _service.RecuperaGaranteExisteAsync(id);
        
        await _uow.IniciarTransacaoAsync();
        _service.Remover(agenda);
        await _uow.CommitTransacaoAsync();
    }
}