using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class AgendamentoAtividadeService : ServiceBase<AgendamentoAtividade, IAgendamentoAtividadeRepository>, IAgendamentoAtividadeService
{
    public AgendamentoAtividadeService(IAgendamentoAtividadeRepository repository)
        : base(repository)
    {
    }

    public async Task<bool> ExisteAtividadeNoAgendamentoAsync(int agendamentoId, int atividadeId)
    {
        return await Repository.AlgumAsync(x => x.AgendamentoId == agendamentoId 
                                                              && x.AtividadeId == atividadeId);
    }

    public async Task GaranteNaoExisteAtividadeNoAgendamentoAsync(int agendamentoId, int atividadeId)
    {
        var exists = await ExisteAtividadeNoAgendamentoAsync(agendamentoId, atividadeId);

        if (exists)
            throw new NacoesAppException(MensagemErroConstant.AtividadeJaVinculadaAoAgendamento);
    }
}