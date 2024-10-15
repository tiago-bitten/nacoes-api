using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class VoluntarioService : ServiceBase<Voluntario, IVoluntarioRepository>, IVoluntarioService
{
    public VoluntarioService(IVoluntarioRepository repository)
        : base(repository)
    {
    }

    public async Task<Voluntario> RecuperarPorChaveAcessoAsync(Guid chaveAcesso, params string[]? includes)
    {
        var existe = await Repository.RecuperarPorChaveAcessoAsync(chaveAcesso, includes);
        
        if (existe is null)
            throw new NacoesAppException("Forneça uma chave de acesso válida");

        return existe;
    }
}