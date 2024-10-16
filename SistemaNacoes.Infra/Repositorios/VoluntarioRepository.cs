using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class VoluntarioRepository : RepositoryBase<Voluntario>, IVoluntarioRepository
{
    public VoluntarioRepository(NacoesDbContext context)
        : base(context)
    {
    }

    public async Task<Voluntario?> RecuperarPorChaveAcessoAsync(Guid chaveAcesso, params string[]? includes)
    {
        return await BuscarAsync(x => x.ChaveAcesso == chaveAcesso, includes);
    }
}