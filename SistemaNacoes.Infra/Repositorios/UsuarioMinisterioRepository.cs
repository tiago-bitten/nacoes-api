using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class UsuarioMinisterioRepository : RepositoryBase<UsuarioMinisterio>, IUsuarioMinisterioRepository
{
    public UsuarioMinisterioRepository(NacoesDbContext context)
        : base(context)
    {
    }
}