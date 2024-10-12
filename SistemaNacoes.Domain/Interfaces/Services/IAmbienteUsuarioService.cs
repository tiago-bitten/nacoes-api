using SistemaNacoes.Domain.Entidades;

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
    bool VerificaUsuarioAutenticado();
}