using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades;

public class RegistroLogin : EntidadeBase
{
    public RegistroLogin() { }
    
    public RegistroLogin(int usuarioId, string ip, string userAgent, DateTime data, bool sucesso)
    {
        UsuarioId = usuarioId;
        Ip = ip;
        UserAgent = userAgent;
        Data = data;
        Sucesso = sucesso;
    }
    
    public int UsuarioId { get; set; }
    public string Ip { get; set; }
    public string UserAgent { get; set; }
    public DateTime Data { get; set; }
    public bool Sucesso { get; set; }
    
    public Usuario Usuario { get; set; }
}