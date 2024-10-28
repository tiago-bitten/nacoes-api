using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Usuario;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAmbienteUsuarioService
{
    Task<Usuario> RecuperaUsuarioAsync(params string[]? includes);
    string? RecuperaUsuarioIp();
    string? RecuperaUsuarioUserAgent();
    int RecuperaUsuarioId();
    List<string>? RecuperaUsuarioRoles();
    string? RecuperaUsuarioNome();
    string? RecuperaUsuarioEmail();
    bool Autenticado();
}