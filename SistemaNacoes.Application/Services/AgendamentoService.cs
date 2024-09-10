using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class AgendamentoService : ServiceBase<Agendamento>, IAgendamentoService
{
    public AgendamentoService(IAgendamentoRepository repository)
        : base(repository)
    {
    }

    public async Task<bool> ExistsVoluntarioJaAgendadoAsync(int agendaId, int voluntarioId)
    {
        return await Repository.AnyAsync(x => x.AgendaId == agendaId
                                               && x.VoluntarioId == voluntarioId
                                               && !x.Removido);
    }

    public async Task EnsureNotExistsVoluntarioJaAgendadoAsync(int agendaId, int voluntarioId)
    {
        var exists = await ExistsVoluntarioJaAgendadoAsync(agendaId, voluntarioId);

        if (exists)
            throw new NacoesAppException(MensagemErroConstant.AgendamentoJaExiste);
    }
}