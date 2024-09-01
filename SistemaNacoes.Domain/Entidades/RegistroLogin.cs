using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Entidades;

public sealed class RegistroLogin : Registro
{
    public RegistroLogin()
    {
    }
    
    public RegistroLogin(int? usuarioId, string ip, string userAgent) 
        : base(usuarioId, ip, userAgent)
    {
        Sucesso = true;
    }
    
    public bool Sucesso { get; set; }
    public EMotivoLoginAcessoNegado? Motivo { get; set; }

    public Usuario? Usuario { get; set; }
}