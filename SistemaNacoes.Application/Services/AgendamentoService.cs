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

    public async Task<bool> ExisteVoluntarioAgendadoAsync(int agendaId, int voluntarioId)
    {
        return await Repository.AlgumAsync(x => x.AgendaId == agendaId
                                               && x.VoluntarioId == voluntarioId);
    }

    public async Task GaranteNaoExisteVoluntarioAgendadoAsync(int agendaId, int voluntarioId)
    {
        var existe = await ExisteVoluntarioAgendadoAsync(agendaId, voluntarioId);

        if (existe)
            throw new NacoesAppException(MensagemErroConstant.AgendamentoJaExiste);
    }
}