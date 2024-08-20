using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IDataIndisponivelService : IServiceBase<DataIndisponivel>
{
    Task<bool> EnsureDateIsAvailable(int agendaId, int voluntarioId);
}