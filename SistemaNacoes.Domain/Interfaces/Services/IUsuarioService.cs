using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IUsuarioService : IServiceBase<Usuario>
{
    Task GaranteNaoExisteUsuarioCriadoAsync(string email, string? cpf);
    Task<Usuario?> RecuperarPorEmailAsync(string email);
}