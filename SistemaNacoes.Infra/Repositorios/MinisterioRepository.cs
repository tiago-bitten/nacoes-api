using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Ministerio;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class MinisterioRepository : RepositoryBase<Ministerio>, IMinisterioRepository
{
    public MinisterioRepository(NacoesDbContext context)
        : base(context)
    {
    }
}