using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Abstracoes;

public abstract class Pessoa : EntidadeBase
{
    public string Nome { get; set; }
    public string? Email { get; set; }
    public string? Celular { get; set; }
    public string? Cpf { get; set; }
    public DateTime? DataNascimento { get; set; }
}