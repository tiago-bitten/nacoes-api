using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IUsuarioMinisterioService : IServiceBase<UsuarioMinisterio>
{
    Task GaranteNaoExisteUsuarioMinisterioAsync(int usuarioId, int ministerioId);
}