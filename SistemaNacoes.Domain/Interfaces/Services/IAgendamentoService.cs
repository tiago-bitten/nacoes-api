using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAgendamentoService : IServiceBase<Agendamento>
{
    Task<bool> ExisteVoluntarioAgendadoAsync(int agendaId, int voluntarioId);
    Task GaranteNaoExisteVoluntarioAgendadoAsync(int agendaId, int voluntarioId);
}