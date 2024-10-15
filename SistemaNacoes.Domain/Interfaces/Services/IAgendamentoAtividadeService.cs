using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAgendamentoAtividadeService : IServiceBase<AgendamentoAtividade>
{
    Task<bool> ExisteAtividadeNoAgendamentoAsync(int agendamentoId, int atividadeId);
    Task GaranteNaoExisteAtividadeNoAgendamentoAsync(int agendamentoId, int atividadeId);
    
}