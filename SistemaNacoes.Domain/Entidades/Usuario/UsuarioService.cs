using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Usuario;

public class UsuarioService : ServiceBase<Usuario, IUsuarioRepository>, IUsuarioService
{
    public UsuarioService(IUsuarioRepository repository) : base(repository)
    {
    }

    #region GaranteNaoExisteUsuarioCriadoAsync
    public async Task GaranteNaoExisteUsuarioCriadoAsync(string email, string? cpf)
    {
        var existePorEmail = await Repository.RecuperarPorEmailAsync(email);
        var existePorCpf = !string.IsNullOrEmpty(cpf) ? await Repository.RecuperarPorCpfAsync(cpf) : null;

        var existentes = new List<string>();

        if (existePorEmail != null)
        {
            var msg = $"o E-mail {email}";
            existentes.Add(msg);
        }
        
        if (existePorCpf != null)
        {
            var msg = $"o CPF {cpf}";
            existentes.Add(msg);
        }
        
        if (existentes.Any())
        {
            var msg = string.Join(" e ", existentes);
            throw new NacoesAppException($"Já existe um usuário cadastrado com {msg}.");
        }
    }
    #endregion
    
    #region RecuperarPorEmailAsync

    public Task<Usuario?> RecuperarPorEmailAsync(string email)
    {
        return Repository.RecuperarPorEmailAsync(email);
    }
    #endregion
}