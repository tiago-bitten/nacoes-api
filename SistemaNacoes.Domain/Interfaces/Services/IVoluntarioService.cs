using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IVoluntarioService : IServiceBase<Voluntario>
{
    Task<Voluntario> RecuperarPorChaveAcessoAsync(Guid chaveAcesso, params string[]? includes);
    Task GaranteNaoExisteCadastradoAsync(string? cpf);
}