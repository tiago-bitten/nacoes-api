using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.DataIndisponivel;

public interface IDataIndisponivelRepository : IRepositoryBase<DataIndisponivel>
{
    Task<List<DataIndisponivel>> RecuperarPorVoluntarioAsync(int voluntarioId);
}