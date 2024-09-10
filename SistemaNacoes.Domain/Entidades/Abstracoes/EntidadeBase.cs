namespace SistemaNacoes.Domain.Entidades.Abstracoes;

public abstract class EntidadeBase
{
    public int Id { get; set; }
    public bool Removido { get; set; } = false;

    public void Remove()
    {
        Removido = true;
    }
}