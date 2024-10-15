using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class GrupoVoluntarioService : ServiceBase<GrupoVoluntario>, IGrupoVoluntarioService
{
    public GrupoVoluntarioService(IGrupoVoluntarioRepository repository) : base(repository)
    {
    }
}