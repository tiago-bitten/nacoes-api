using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAmbienteUsuarioService
{
    Task<Usuario> GetUsuarioAsync();
}