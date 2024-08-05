using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class VoluntarioRepository : RepositoryBase<Voluntario>
{
    public VoluntarioRepository(NacoesDbContext context)
        : base(context)
    {
    }
}