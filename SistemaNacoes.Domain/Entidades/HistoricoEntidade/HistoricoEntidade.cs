using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.HistoricoEntidade;

public sealed class HistoricoEntidade : EntidadeBase
{
    public string Tabela { get; set; }
    public int ItemId { get; set; }
    public int? UsuarioId { get; set; }
    public DateTime Data { get; set; } = DateTime.UtcNow;
    public string Ip { get; set; }
    public string UserAgent { get; set; }
    public string Descricao { get; set; }
    
    public Usuario.Usuario? Usuario { get; set; }
    
    public HistoricoEntidade()
    {
    }

    public HistoricoEntidade(string tabela, int itemId, int? usuarioId, string ip, string userAgent, string descricao)
    {
        Tabela = tabela;
        ItemId = itemId;
        UsuarioId = usuarioId;
        Ip = ip;
        UserAgent = userAgent;
        Descricao = descricao;
    }
}