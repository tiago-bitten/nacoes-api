using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAgendamentoAtividadeService
{
    Task<AgendamentoAtividade> GetAndEnsureExistsAsync(int agendamentoId, int atividadeId);
    Task<bool> ExistsAtividadeNoAgendamentoAsync(int agendamentoId, int atividadeId);
    Task EnsureNotExistsAtividadeNoAgendamentoAsync(int agendamentoId, int atividadeId);
}