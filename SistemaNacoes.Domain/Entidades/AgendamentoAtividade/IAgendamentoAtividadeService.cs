using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.AgendamentoAtividade;

public interface IAgendamentoAtividadeService : IServiceBase<AgendamentoAtividade>
{
    Task<bool> ExisteAtividadeNoAgendamentoAsync(int agendamentoId, int atividadeId);
    Task GaranteNaoExisteAtividadeNoAgendamentoAsync(int agendamentoId, int atividadeId);
    
}