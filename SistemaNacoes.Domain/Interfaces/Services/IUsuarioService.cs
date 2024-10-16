using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IUsuarioService : IServiceBase<Usuario>
{
    Task GaranteNaoExisteUsuarioCriadoAsync(string email, string? cpf);
}