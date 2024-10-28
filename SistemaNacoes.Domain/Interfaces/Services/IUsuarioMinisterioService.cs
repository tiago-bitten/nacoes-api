using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IUsuarioMinisterioService : IServiceBase<UsuarioMinisterio>
{
    Task GaranteNaoExisteUsuarioMinisterioAsync(int usuarioId, int ministerioId);
}