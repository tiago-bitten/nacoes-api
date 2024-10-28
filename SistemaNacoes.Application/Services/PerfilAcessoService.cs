using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class PerfilAcessoService : ServiceBase<PerfilAcesso, IPerfilAcessoRepository>, IPerfilAcessoService
{
    public PerfilAcessoService(IPerfilAcessoRepository repository) : base(repository)
    {
    }
}