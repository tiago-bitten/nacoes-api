using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.PerfilAcesso;

public class PerfilAcessoService : ServiceBase<PerfilAcesso, IPerfilAcessoRepository>, IPerfilAcessoService
{
    public PerfilAcessoService(IPerfilAcessoRepository repository) : base(repository)
    {
    }
}