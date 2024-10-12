using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class GrupoRepository : RepositoryBase<Grupo>, IGrupoRepository
{
    public GrupoRepository(NacoesDbContext context)
        : base(context)
    {
    }
}