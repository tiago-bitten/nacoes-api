namespace SistemaNacoes.Domain.Entidades.Infra;

public interface IAmbienteUsuarioService
{
    Task<Usuario.Usuario> RecuperaUsuarioAsync(params string[]? includes);
    string? RecuperaUsuarioIp();
    string? RecuperaUsuarioUserAgent();
    int RecuperaUsuarioId();
    List<string>? RecuperaUsuarioRoles();
    string? RecuperaUsuarioNome();
    string? RecuperaUsuarioEmail();
    bool Autenticado();
}