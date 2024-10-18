using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IVoluntarioMinisterioService : IServiceBase<VoluntarioMinisterio>
{
    Task<bool> ExisteVoluntarioNoMinisterio(int voluntarioId, int ministerioId);
    Task GaranteNaoExisteVoluntarioNoMinisterio(int voluntarioId, int ministerioId);
}