using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Shared.Extensions;

public static class  PermissoesExtensions
{
    public static bool PossuiPermissao(this Usuario usuario, EPermissoes permissao)
    {
        return (usuario.PerfilAcesso.Permissoes & permissao) == permissao;
    }
}