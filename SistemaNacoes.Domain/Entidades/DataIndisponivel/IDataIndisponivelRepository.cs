using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Domain.Entidades.DataIndisponivel;

public interface IDataIndisponivelRepository : IRepositoryBase<DataIndisponivel>
{
    Task<List<DataIndisponivel>> RecuperarPorVoluntarioAsync(int voluntarioId);
}