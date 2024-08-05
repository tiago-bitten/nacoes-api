using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class UsuarioRepository : RepositoryBase<Usuario>
{
    public UsuarioRepository(NacoesDbContext context)
        : base(context)
    {
    }
}