using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Agendamento;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class AgendamentoRepository : RepositoryBase<Agendamento>, IAgendamentoRepository
{
    public AgendamentoRepository(NacoesDbContext context)
        : base(context)
    {
    }
}