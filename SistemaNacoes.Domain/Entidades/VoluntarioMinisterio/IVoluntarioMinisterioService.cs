using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.VoluntarioMinisterio;

public interface IVoluntarioMinisterioService : IServiceBase<VoluntarioMinisterio>
{
    Task<bool> ExisteVoluntarioNoMinisterio(int voluntarioId, int ministerioId);
    Task GaranteNaoExisteVoluntarioNoMinisterio(int voluntarioId, int ministerioId);
}