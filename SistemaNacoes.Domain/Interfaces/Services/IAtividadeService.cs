using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAtividadeService : IServiceBase<Atividade>
{
    Task EnsureExistsAtividadeNoMinisterioAsync(int id, int ministerioId);
    Task<bool> ExistsAtividadeNoMinisterioAsync(int id, int ministerioId);
    Task<bool> ExitsAtividadeNoAgendamentoAsync(int id, int agendamentoId);
    Task EnsureNotExistAtividadeNoMinisterioAsync(int id, int ministerioId);
}