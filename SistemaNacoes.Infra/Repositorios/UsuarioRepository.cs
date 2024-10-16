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

    public async Task<Usuario?> RecuperarPorEmail(string email)
    {
        return await BuscarAsync(x => !string.IsNullOrEmpty(x.Email) 
                                      && x.Email.ToLower() == email.ToLower());
    }

    public async Task<Usuario?> RecuperarPorCpf(string cpf)
    {
        return await BuscarAsync(x => x.Cpf == cpf);
    }
}