using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class EscalaItemRepository : RepositoryBase<EscalaItem>, IEscalaItemRepository
{
    public EscalaItemRepository(NacoesDbContext context)
        : base(context)
    {
    }
}