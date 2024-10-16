using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(NacoesDbContext context)
        : base(context)
    {
    }

    public async Task<bool> ExisteUsuarioCriadoAsync(string email, string? cpf)
    {
        return await AlgumAsync(x => x.Email == email || (!string.IsNullOrEmpty(cpf) && x.Cpf == cpf));
    }
}