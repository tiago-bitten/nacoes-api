using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Entidades.PerfilAcesso;

public class PerfilAcesso : EntidadeBase
{
    public string Nome { get; set; }
    public EPermissoes Permissoes { get; set; } = EPermissoes.Nenhuma;

    public List<Usuario> Usuarios { get; set; } = new();
}