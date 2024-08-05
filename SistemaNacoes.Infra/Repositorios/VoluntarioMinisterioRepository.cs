using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class VoluntarioMinisterioRepository : RepositoryBase<VoluntarioMinisterio>, IVoluntarioMinisterioRepository
{
    public VoluntarioMinisterioRepository(NacoesDbContext context)
        : base(context)
    {
    }
}