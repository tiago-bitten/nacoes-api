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
        var existentes = new List<string>();

        var existePorEmail = await Repository.RecuperarPorEmailAsync(email);
        var existePorCpf = cpf != null ? await Repository.RecuperarPorCpfAsync(cpf) : null;

        if (existePorEmail != null)
        {
            existentes.Add($"o E-mail {email}");
        }

        if (existePorCpf != null)
        {
            existentes.Add($"o CPF {cpf}");
        }

        if (existentes.Any())
        {
            var mensagem = string.Join(" e ", existentes);
            throw new NacoesAppException($"Já existe um usuário com {mensagem} registrado.");
        }

    }
}