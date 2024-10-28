using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.GrupoVoluntario;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class GrupoVoluntarioRepository : RepositoryBase<GrupoVoluntario>, IGrupoVoluntarioRepository
{
    public GrupoVoluntarioRepository(NacoesDbContext context)
        : base(context)
    {
    }
}