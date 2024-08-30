using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Entidades;

public class RegistroLogin : EntidadeBase
{
    public RegistroLogin() { }
    
    public RegistroLogin(int? usuarioId, string ip, string userAgent)
    {
        UsuarioId = usuarioId;
        Ip = ip;
        UserAgent = userAgent;
        Sucesso = true;
    }
    
    public int? UsuarioId { get; set; }
    public string Ip { get; set; }
    public string UserAgent { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public bool Sucesso { get; set; }
    public EMotivoLoginAcessoNegado? Motivo { get; set; }

    public Usuario? Usuario { get; set; } = null;
}