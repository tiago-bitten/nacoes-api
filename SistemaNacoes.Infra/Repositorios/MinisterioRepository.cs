using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class MinisterioRepository : RepositoryBase<Ministerio>
{
    public MinisterioRepository(NacoesDbContext context)
        : base(context)
    {
    }
}