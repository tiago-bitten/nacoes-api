using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class EscalaItemRepository : RepositoryBase<EscalaItem>
{
    public EscalaItemRepository(NacoesDbContext context)
        : base(context)
    {
    }
}