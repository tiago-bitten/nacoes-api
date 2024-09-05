using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class AtividadeService : ServiceBase<Atividade>, IAtividadeService
{
    public AtividadeService(IAtividadeRepository repository)
        : base(repository)
    {
    }

    public async Task EnsureExistsAtividadeNoMinisterioAsync(int atividadeId, int ministerioId)
    {
        var exists = await ExistsAtividadeNoMinisterioAsync(atividadeId, ministerioId);

        if (!exists)
            throw new NacoesAppException(MensagemErroConstant.AtividadeNaoPertenceAoMinisterio);
    }

    public async Task<bool> ExistsAtividadeNoMinisterioAsync(int atividadeId, int ministerioId)
    {
        return await _repository.AnyAsync(x => x.Id == atividadeId
                                                        && x.MinisterioId == ministerioId && !x.Ministerio.Removido
                                                        && !x.Removido, "Ministerio");
    }

    public async Task<bool> ExitsAtividadeNoAgendamentoAsync(int atividadeId, int agendamentoId)
    {
        return await _repository.AnyAsync(x => x.Id == atividadeId
                                               && x.AgendamentoAtividades
                                                   .Any(at => at.AgendamentoId == agendamentoId && !at.Removido)
                                               && !x.Removido, "AgendamentoAtividades");
    }

    public async Task EnsureNotExistAtividadeNoMinisterioAsync(int atividadeId, int ministerioId)
    {
        var exists = await ExistsAtividadeNoMinisterioAsync(atividadeId, ministerioId);
        
        if (!exists)
            throw new NacoesAppException(MensagemErroConstant.AtividadeNaoPertenceAoMinisterio);
    }
}