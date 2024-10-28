using SistemaNacoes.Domain.Entidades.Agendamento;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos.RemoverAgendamento;

public class RemoverAgendamento : IRemoverAgendamentoUseCase
{
    private readonly IAgendamentoService _service;
    private readonly IUnitOfWork _uow;
    private readonly IHistoricoEntidadeService _historicoService;
    
    public RemoverAgendamento(IUnitOfWork uow, IAgendamentoService agendamentoService, IHistoricoEntidadeService historicoService)
    {
        _uow = uow;
        _service = agendamentoService;
        _historicoService = historicoService;
    }

    public async Task ExecutarAsync(int id)
    {
        var agendamento = await _service.RecuperaGaranteExisteAsync(id);

        await _uow.IniciarTransacaoAsync();
        _service.Remover(agendamento);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("agendamentos", agendamento.Id, "Removeu agendamento.");
        await _uow.CommitTransacaoAsync();
    }
}