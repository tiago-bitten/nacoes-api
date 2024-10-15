using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;

namespace SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;

public interface ICriarAgendamentoUseCase : ICommandUseCaseBase<CriarAgendamentoResult, CriarAgendamentoRequest>
{
    
}