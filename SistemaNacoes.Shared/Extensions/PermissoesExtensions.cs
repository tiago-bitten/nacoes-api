using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Application.Extensions;

public static class  PermissoesExtensions
{
    public static bool HasPermission(this Usuario usuario, EPermissoes permissao)
    {
        return (usuario.Permissoes & permissao) == permissao;
    }
}