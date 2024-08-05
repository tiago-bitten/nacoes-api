using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class EscalaRepository : RepositoryBase<Escala>
{
    public EscalaRepository(NacoesDbContext context)
        : base(context)
    {
    }
}