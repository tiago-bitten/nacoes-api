namespace SistemaNacoes.Domain.Enterprise;

public class NacoesAppException : Exception
{
    public NacoesAppException(string message) : base(message)
    {
    }
}