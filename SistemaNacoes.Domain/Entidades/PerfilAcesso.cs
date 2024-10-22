using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Entidades;

public class PerfilAcesso : EntidadeBase
{
    public string Nome { get; set; }
    public EPermissoes Permissoes { get; set; } = EPermissoes.Nenhuma;

    public List<Usuario> Usuarios { get; set; } = new();
}