using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades;

public class RefreshToken : EntidadeBase
{
    public RefreshToken(string token, string principal, DateTime dataExpiracao)
    {
        Token = token;
        Principal = principal;
        DataExpiracao = dataExpiracao;
    }
    
    public string Token { get; set; }
    public string Principal { get; set; }
    public bool Revogado { get; set; } = false;
    public DateTime DataExpiracao { get; set; }

    public bool Invalido => Revogado || DataExpiracao < DateTime.UtcNow;
    
    public void Revogar() => Revogado = true;
}
