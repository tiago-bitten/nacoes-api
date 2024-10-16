using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class UsuarioService : ServiceBase<Usuario, IUsuarioRepository>, IUsuarioService
{
    public UsuarioService(IUsuarioRepository repository) : base(repository)
    {
    }

    public async Task GaranteNaoExisteUsuarioCriadoAsync(string email, string? cpf)
    {
        var existe = await Repository.ExisteUsuarioCriadoAsync(email, cpf);
        
        if (existe)
            throw new NacoesAppException("Usuário com ")
    }
}