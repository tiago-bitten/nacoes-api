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

    public async Task EnsureExistsAtividadeNoMinisterioAsync(int id, int ministerioId)
    {
        var exists = await ExistsAtividadeNoMinisterioAsync(id, ministerioId);

        if (!exists)
            throw new NacoesAppException(MensagemErroConstant.AtividadeNaoPertenceAoMinisterio);
    }

    public async Task<bool> ExistsAtividadeNoMinisterioAsync(int id, int ministerioId)
    {
        return await _repository.AnyAsync(x => x.Id == id
                                                        && x.MinisterioId == ministerioId && !x.Ministerio.Removido
                                                        && !x.Removido, "Ministerio");
    }

    public async Task<bool> ExitsAtividadeNoAgendamentoAsync(int id, int agendamentoId)
    {
        return await _repository.AnyAsync(x => x.Id == id
                                               && x.AgendamentoAtividades.Any(at => at.AgendamentoId == agendamentoId && !at.Removido)
                                               && !x.Removido, "AgendamentoAtividades");
    }

    public async Task EnsureNotExistAtividadeNoMinisterioAsync(int id, int ministerioId)
    {
        var exists = await ExistsAtividadeNoMinisterioAsync(id, ministerioId);
        
        if (!exists)
            throw new NacoesAppException(MensagemErroConstant.AtividadeNaoPertenceAoMinisterio);
    }
}