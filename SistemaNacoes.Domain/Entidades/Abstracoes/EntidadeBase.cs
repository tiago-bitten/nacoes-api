namespace SistemaNacoes.Domain.Entidades.Abstracoes;

public abstract class EntidadeBase
{
    public int Id { get; set; }
    public bool Removido { get; private set; } = false;
    public DateTime DataCriacao { get; private set; } = DateTime.Now;

    public void Remover()
    {
        Removido = true;
    }
}