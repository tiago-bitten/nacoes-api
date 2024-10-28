using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Domain.Entidades.GrupoVoluntario;

public class GrupoVoluntarioService : ServiceBase<GrupoVoluntario, IGrupoVoluntarioRepository>, IGrupoVoluntarioService
{
    public GrupoVoluntarioService(IGrupoVoluntarioRepository repository) : base(repository)
    {
    }
}