using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class SituacaoAgendamentoRepository : RepositoryBase<SituacaoAgendamento>, ISituacaoAgendamentoRepository
{
    public SituacaoAgendamentoRepository(NacoesDbContext context) : base(context)
    {
    }
}