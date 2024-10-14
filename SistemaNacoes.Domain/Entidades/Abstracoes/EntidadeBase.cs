using SistemaNacoes.Domain.Enterprise;

namespace SistemaNacoes.Domain.Entidades.Abstracoes;

public abstract class EntidadeBase
{
    public int Id { get; set; }
    public bool Removido { get; private set; } = false;
    public DateTime DataCriacao { get; private set; } = DateTime.Now;

    #region Remover
    public void Remover()
    {
        Removido = true;
    }
    #endregion
    
    #region ValidarRemovido
    public void ValidarRemovido()
    {
        if (Removido)
            throw new NacoesAppException("Entidade está removida");
    }
    #endregion
}