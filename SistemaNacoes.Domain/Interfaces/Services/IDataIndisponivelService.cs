using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IDataIndisponivelService : IServiceBase<DataIndisponivel>
{
    bool ExisteDataDisponivel(DateTime dataInicial, DateTime dataFinal, List<DataIndisponivel> datasIndisponiveis);
    void GaranteExisteDataDisponivel(DateTime dataInicial, DateTime dataFinal, List<DataIndisponivel> datasIndisponiveis);
    void Suspender(DataIndisponivel dataIndisponivel);
    Task<List<DataIndisponivel>> RecuperarPorVoluntarioAsync(int voluntarioId);
}