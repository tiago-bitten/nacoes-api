using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class GrupoRepository : RepositoryBase<Grupo>
{
    public GrupoRepository(NacoesDbContext context)
        : base(context)
    {
    }
}