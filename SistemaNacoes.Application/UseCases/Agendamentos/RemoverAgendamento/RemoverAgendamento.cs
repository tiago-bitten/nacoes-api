using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos.RemoverAgendamento;

public class RemoverAgendamento : IRemoverAgendamentoUseCase
{
    private readonly IAgendamentoService _service;
    private readonly IUnitOfWork _uow;

    public RemoverAgendamento(IUnitOfWork uow, IAgendamentoService agendamentoService)
    {
        _uow = uow;
        _service = agendamentoService;
    }

    public async Task ExecutarAsync(int id)
    {
        var agendamento = await _service.RecuperaGaranteExisteAsync(id);

        await _uow.IniciarTransacaoAsync();
        _service.Remover(agendamento);
        await _uow.CommitTransacaoAsync();
    }
}