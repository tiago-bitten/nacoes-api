using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendamentos.RemoverAgendamento;

public class RemoverAgendamento : UseCaseBase, IRemoverAgendamentoUseCase
{
    private readonly IAgendamentoService _agendamentoService;

    public RemoverAgendamento(IUnitOfWork uow, IAgendamentoService agendamentoService) : base(uow)
    {
        _agendamentoService = agendamentoService;
    }

    public async Task ExecutarAsync(int id)
    {
        var agendamento = await _agendamentoService.RecuperaGaranteExisteAsync(id);

        await IniciarTransacaoAsync();
        _agendamentoService.Remover(agendamento);
        await CommitTransacaoAsync();
    }
}