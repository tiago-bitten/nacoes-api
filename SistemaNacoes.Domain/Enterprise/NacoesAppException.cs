namespace SistemaNacoes.Domain.Enterprise;

public class NacoesAppException : Exception
{
    protected NacoesAppException(string message) : base(message)
    {
    }
}