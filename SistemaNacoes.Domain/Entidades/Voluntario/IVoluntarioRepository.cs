using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Voluntario;

public interface IVoluntarioRepository : IRepositoryBase<Voluntario>
{
    Task<Voluntario?> RecuperarPorChaveAcessoAsync(Guid chaveAcesso, params string[]? includes);
    Task<Voluntario?> RecuperarPorCpfAsync(string cpf);
    IQueryable<Voluntario> RecuperarParaAgendar(int agendaId, int ministerioId);
}