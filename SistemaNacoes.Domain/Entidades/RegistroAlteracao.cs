using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades;

public sealed class RegistroAlteracao : Registro
{
    public string DadosAntigos { get; set; }
    public string DadosNovos { get; set; }
}