using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAtividadeService : IServiceBase<Atividade>
{
    Task EnsureExistsAtividadeNoMinisterioAsync(int id, int ministerioId);
    Task<bool> ExisteAtividadeNoMinisterioAsync(int id, int ministerioId);
}