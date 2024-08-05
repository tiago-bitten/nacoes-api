using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class VoluntarioMinisterioRepository : RepositoryBase<VoluntarioMinisterio>
{
    public VoluntarioMinisterioRepository(NacoesDbContext context)
        : base(context)
    {
    }
}