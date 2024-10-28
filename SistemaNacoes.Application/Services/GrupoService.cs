using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class GrupoService : ServiceBase<Grupo, IGrupoRepository>, IGrupoService
{
    public GrupoService(IGrupoRepository repository) : base(repository)
    {
    }
}