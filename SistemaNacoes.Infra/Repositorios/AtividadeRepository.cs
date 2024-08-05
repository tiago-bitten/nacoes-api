using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class AtividadeRepository : RepositoryBase<Atividade>
{
    public AtividadeRepository(NacoesDbContext context)
        : base(context)
    {
    }
}