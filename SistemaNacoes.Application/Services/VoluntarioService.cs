using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class VoluntarioService : ServiceBase<Voluntario>, IVoluntarioService
{
    public VoluntarioService(IVoluntarioRepository repository)
        : base(repository)
    {
    }

    public async Task<Voluntario> GetByChaveAcessoAsync(Guid chaveAcesso)
    {
        var exists = await Repository.BuscarAsync(x => x.ChaveAcesso == chaveAcesso);
        
        if (exists == null)
            throw new Exception("Forneça uma chave de acesso válida");
        
        return exists;
    }
}