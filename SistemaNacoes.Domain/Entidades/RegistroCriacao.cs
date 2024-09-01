using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades;

public sealed class RegistroCriacao : Registro
{
    public RegistroCriacao()
    {
    }

    public RegistroCriacao(string tabela, int itemId, int? usuarioId, string ip, string userAgent)
        : base(tabela, itemId, usuarioId, ip, userAgent)
    {
    }
}