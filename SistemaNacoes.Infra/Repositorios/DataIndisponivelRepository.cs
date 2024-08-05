using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class DataIndisponivelRepository : RepositoryBase<DataIndisponivel>
{
    public DataIndisponivelRepository(NacoesDbContext context)
        : base(context)
    {
    }
}