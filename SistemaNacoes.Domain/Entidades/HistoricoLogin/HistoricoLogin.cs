using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Entidades.HistoricoLogin;

public sealed class HistoricoLogin : EntidadeBase
{
    public int? UsuarioId { get; set; }    
    public string Ip { get; set; }
    public string UserAgent { get; set; }
    public DateTime DataAcesso { get; set; } = DateTime.Now;
    public bool Sucesso { get; set; }
    public EMotivoLoginAcessoNegado? Motivo { get; set; }

    public Usuario? Usuario { get; set; }
}