using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
{
    public UsuarioService(IUsuarioRepository repository) : base(repository)
    {
    }
}