using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IVoluntarioMinisterioService
{
    Task<VoluntarioMinisterio> GetAndEnsureExistsAsync(int voluntarioId, int ministerioId);
}