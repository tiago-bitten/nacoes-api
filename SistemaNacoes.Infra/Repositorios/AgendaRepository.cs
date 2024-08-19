using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class AgendaRepository : RepositoryBase<Agenda>, IAgendaRepository
{
    public AgendaRepository(NacoesDbContext context)
        : base(context)
    {
    }
}