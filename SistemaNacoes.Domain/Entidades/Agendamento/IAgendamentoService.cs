using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Agendamento;

public interface IAgendamentoService : IServiceBase<Agendamento>
{
    Task<bool> ExisteVoluntarioAgendadoAsync(int agendaId, int voluntarioId);
    Task GaranteNaoExisteVoluntarioAgendadoAsync(int agendaId, int voluntarioId);
}