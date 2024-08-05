using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class UsuarioMinisterioRepository : RepositoryBase<UsuarioMinisterio>
{
    public UsuarioMinisterioRepository(NacoesDbContext context)
        : base(context)
    {
    }
}