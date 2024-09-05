using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAgendamentoService : IServiceBase<Agendamento>
{
    Task<bool> ExistsVoluntarioJaAgendadoAsync(int agendaId, int voluntarioId);
    Task EnsureNotExistsVoluntarioJaAgendadoAsync(int agendaId, int voluntarioId);
}