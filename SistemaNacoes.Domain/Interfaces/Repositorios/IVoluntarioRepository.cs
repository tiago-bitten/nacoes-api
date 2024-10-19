using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Repositorios;

public interface IVoluntarioRepository : IRepositoryBase<Voluntario>
{
    Task<Voluntario?> RecuperarPorChaveAcessoAsync(Guid chaveAcesso, params string[]? includes);
    Task<Voluntario?> RecuperarPorCpfAsync(string cpf);
    IQueryable<Voluntario> RecuperarParaAgendar(int agendaId, int ministerioId);
}