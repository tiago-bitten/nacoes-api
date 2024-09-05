using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IDataIndisponivelService : IServiceBase<DataIndisponivel>
{
    Task<bool> ExistsDataAvaliableAsync(int agenda, int voluntarioId);
    Task EnsureExistsDataAvaliableAsync(int agendaId, int voluntarioId);
}