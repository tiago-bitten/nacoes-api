using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class EscalaRepository : RepositoryBase<Escala>, IEscalaRepository
{
    public EscalaRepository(NacoesDbContext context)
        : base(context)
    {
    }
}