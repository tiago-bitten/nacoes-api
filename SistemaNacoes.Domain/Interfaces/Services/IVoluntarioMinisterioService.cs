using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IVoluntarioMinisterioService : IServiceBase<VoluntarioMinisterio>
{
    Task<bool> ExisteVoluntarioNoMinisterio(int voluntarioId, int ministerioId);
    Task GaranteNaoExisteVoluntarioNoMinisterio(int voluntarioId, int ministerioId);
}