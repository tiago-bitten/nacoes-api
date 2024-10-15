using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades;

public sealed class HistoricoEntidade : EntidadeBase
{
    public HistoricoEntidade()
    {
    }
    
    public HistoricoEntidade(string ip, string userAgent)
    {
        Ip = ip;
        UserAgent = userAgent;
    }

    public HistoricoEntidade(int usuarioId, string ip, string userAgent)
    {
        UsuarioId = usuarioId;
        Ip = ip;
        UserAgent = userAgent;
    }

    public HistoricoEntidade(string tabela, int itemId, int usuarioId, string ip, string userAgent)
    {
        Tabela = tabela;
        ItemId = itemId;
        UsuarioId = usuarioId;
        Ip = ip;
        UserAgent = userAgent;
    }
    
    public string Tabela { get; set; }
    public int ItemId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime Data { get; set; } = DateTime.UtcNow;
    public string Ip { get; set; }
    public string UserAgent { get; set; }
    public string Descricao { get; set; }
    
    public Usuario Usuario { get; set; }
}