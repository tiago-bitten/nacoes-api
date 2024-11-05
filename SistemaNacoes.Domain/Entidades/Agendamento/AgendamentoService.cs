using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Agendamento;

public class AgendamentoService : ServiceBase<Agendamento, IAgendamentoRepository>, IAgendamentoService
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