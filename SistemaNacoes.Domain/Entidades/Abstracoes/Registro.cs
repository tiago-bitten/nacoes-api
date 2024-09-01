using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaNacoes.Domain.Entidades.Abstracoes;

public abstract class Registro : EntidadeBase
{
    public Registro()
    {
    }
    
    public Registro(string ip, string userAgent)
    {
        Ip = ip;
        UserAgent = userAgent;
    }

    public Registro(int? usuarioId, string ip, string userAgent)
    {
        UsuarioId = usuarioId;
        Ip = ip;
        UserAgent = userAgent;
    }

    public Registro(string tabela, int itemId, int? usuarioId, string ip, string userAgent)
    {
        Tabela = tabela;
        ItemId = itemId;
        UsuarioId = usuarioId;
        Ip = ip;
        UserAgent = userAgent;
    }
    
    public string? Tabela { get; set; }
    public int? ItemId { get; set; }
    public int? UsuarioId { get; set; }
    public DateTime Data { get; set; } = DateTime.UtcNow;
    public string Ip { get; set; }
    public string UserAgent { get; set; }
    
    public Usuario? Usuario { get; set; }
}