using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Repositorios;

public interface IDataIndisponivelRepository : IRepositoryBase<DataIndisponivel>
{
    Task<List<DataIndisponivel>> RecuperarPorVoluntarioAsync(int voluntarioId);
}