using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.PerfilAcesso;
using SistemaNacoes.Domain.Entidades.Usuario;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Shared.Extensions;

public static class  PermissoesExtensions
{
    public static bool PossuiPermissao(this Usuario usuario, EPermissoes permissao)
    {
        return (usuario.PerfilAcesso.Permissoes & permissao) == permissao;
    }
    
    public static void AdicionarPermissao(this PerfilAcesso perfilAcesso, params EPermissoes[] permissoes)
    {
        foreach (var permissao in permissoes)
        {
            perfilAcesso.Permissoes |= permissao;
        }
    }
    
    public static void RemoverPermissao(this PerfilAcesso perfilAcesso, params EPermissoes[] permissoes)
    {
        foreach (var permissao in permissoes)
        {
            perfilAcesso.Permissoes &= ~permissao;
        }
    }
}