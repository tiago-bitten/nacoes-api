using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.DataIndisponivel;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class DataIndisponivelRepository : RepositoryBase<DataIndisponivel>, IDataIndisponivelRepository
{
    public DataIndisponivelRepository(NacoesDbContext context)
        : base(context)
    {
    }

    public Task<List<DataIndisponivel>> RecuperarPorVoluntarioAsync(int voluntarioId)
    {
        return BuscarTodos(x => x.VoluntarioId == voluntarioId).ToListAsync();
    }
}