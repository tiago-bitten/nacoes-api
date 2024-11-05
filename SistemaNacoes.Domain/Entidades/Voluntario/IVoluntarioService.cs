using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Voluntario;

public interface IVoluntarioService : IServiceBase<Voluntario>
{
    Task<Voluntario> RecuperarPorChaveAcessoAsync(Guid chaveAcesso, params string[]? includes);
    Task GaranteNaoExisteCadastradoAsync(string? cpf);
    IQueryable<Voluntario> RecuperarParaAgendar(int agendaId, int ministerioId);
}