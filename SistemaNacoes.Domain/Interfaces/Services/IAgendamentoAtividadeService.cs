using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAgendamentoAtividadeService : IServiceBase<AgendamentoAtividade>
{
    Task<bool> ExistsAtividadeNoAgendamentoAsync(int agendamentoId, int atividadeId);
    Task EnsureNotExistsAtividadeNoAgendamentoAsync(int agendamentoId, int atividadeId);
}