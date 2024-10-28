using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.UsuarioMinisterio;

public interface IUsuarioMinisterioService : IServiceBase<UsuarioMinisterio>
{
    Task GaranteNaoExisteUsuarioMinisterioAsync(int usuarioId, int ministerioId);
}