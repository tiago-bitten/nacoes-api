namespace SistemaNacoes.Domain.Entidades.Abstracoes;

public abstract class Registro : EntidadeBase
{
    public string? Tabela { get; set; }
    public int? ItemId { get; set; }
    public int? UsuarioId { get; set; }
    public DateTime Data { get; set; }
    public string Ip { get; set; }
    public string UserAgent { get; set; }
    
    public Usuario? Usuario { get; set; }
}