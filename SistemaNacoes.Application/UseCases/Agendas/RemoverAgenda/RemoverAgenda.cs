using SistemaNacoes.Domain.Entidades.Agenda;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendas.RemoverAgenda;

public class RemoverAgenda : IRemoverAgendaUseCase
{
    private readonly IAgendaService _service;
    private readonly IUnitOfWork _uow;
    private readonly IHistoricoEntidadeService _historicoService;
    
    public RemoverAgenda(IAgendaService service, IUnitOfWork uow, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _uow = uow;
        _historicoService = historicoService;
    }

    public async Task ExecutarAsync(int id)
    {
        var agenda = await _service.RecuperaGaranteExisteAsync(id);
        
        await _uow.IniciarTransacaoAsync();
        _service.Remover(agenda);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("agendas", agenda.Id, "Removeu agenda.");
        await _uow.CommitTransacaoAsync();
    }
}