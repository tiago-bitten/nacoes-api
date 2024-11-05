using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Atividade;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class AtividadeRepository : RepositoryBase<Atividade>, IAtividadeRepository
{
    public AtividadeRepository(NacoesDbContext context)
        : base(context)
    {
    }
}