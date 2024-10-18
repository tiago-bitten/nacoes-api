using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IDataIndisponivelService : IServiceBase<DataIndisponivel>
{
    Task<bool> ExisteDataDisponivelAsync(int agenda, int voluntarioId);
    Task GaranteExisteDataDisponivelAsync(int agendaId, int voluntarioId);
    void Suspender(DataIndisponivel dataIndisponivel);
}