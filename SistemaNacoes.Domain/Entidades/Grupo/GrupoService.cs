using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Domain.Entidades.Grupo;

public class GrupoService : ServiceBase<Grupo, IGrupoRepository>, IGrupoService
{
    public GrupoService(IGrupoRepository repository) : base(repository)
    {
    }
}