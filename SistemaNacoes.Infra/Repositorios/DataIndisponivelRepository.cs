using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class DataIndisponivelRepository : RepositoryBase<DataIndisponivel>, IDataIndisponivelRepository
{
    public DataIndisponivelRepository(NacoesDbContext context)
        : base(context)
    {
    }
}