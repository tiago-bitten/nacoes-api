using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Voluntario;
using SistemaNacoes.Domain.Interfaces.Repositorios;
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

    public Task<Voluntario?> RecuperarPorCpfAsync(string cpf)
    {
        return BuscarAsync(x => x.Cpf == cpf);
    }

    public IQueryable<Voluntario> RecuperarParaAgendar(int agendaId, int ministerioId)
    {
        return (from v in Context.Voluntarios
                join vm in Context.VoluntarioMinisterios on v.Id equals vm.VoluntarioId
                join m in Context.Ministerios on vm.MinisterioId equals m.Id
                join a in Context.Agendamentos on v.Id equals a.VoluntarioId into agendamentos
                from a in agendamentos.DefaultIfEmpty()
                where !v.Removido
                      && !vm.Removido
                      && !m.Removido
                      && vm.MinisterioId == ministerioId
                      && (a.AgendaId != agendaId || a.Removido)
                select v)
            .Distinct()
            .Include(x => x.DataIndisponiveis.Where(y => 
                !y.Removido && !y.Suspenso
                && y.DataFinal.Date >= DateTime.Now.Date));
    }
}