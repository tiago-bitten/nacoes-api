using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Usuario;

public interface IUsuarioService : IServiceBase<Usuario>
{
    Task GaranteNaoExisteUsuarioCriadoAsync(string email, string? cpf);
    Task<Usuario?> RecuperarPorEmailAsync(string email);
}