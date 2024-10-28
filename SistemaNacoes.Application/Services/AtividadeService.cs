using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class AtividadeService : ServiceBase<Atividade, IAtividadeRepository>, IAtividadeService
{
    public AtividadeService(IAtividadeRepository repository)
        : base(repository)
    {
    }

    public async Task EnsureExistsAtividadeNoMinisterioAsync(int atividadeId, int ministerioId)
    {
        var exists = await ExisteAtividadeNoMinisterioAsync(atividadeId, ministerioId);

        if (!exists)
            throw new NacoesAppException(MensagemErroConstant.AtividadeNaoPertenceAoMinisterio);
    }

    public async Task<bool> ExisteAtividadeNoMinisterioAsync(int atividadeId, int ministerioId)
    {
        return await Repository.AlgumAsync(x => x.Id == atividadeId
                                                        && x.MinisterioId == ministerioId);
    }

    // todo: passar para AgendamentoAtividadeService
    public async Task<bool> ExisteAtividadeNoAgendamentoAsync(int atividadeId, int agendamentoId)
    {
        return await Repository.AlgumAsync(x => x.Id == atividadeId
                                               && x.AgendamentoAtividades
                                                   .Any(at => at.AgendamentoId == agendamentoId));
    }

    public async Task GaranteNaoExisteAtividadeNoMinisterioAsync(int atividadeId, int ministerioId)
    {
        var exists = await ExisteAtividadeNoMinisterioAsync(atividadeId, ministerioId);
        
        if (!exists)
            throw new NacoesAppException(MensagemErroConstant.AtividadeNaoPertenceAoMinisterio);
    }
}