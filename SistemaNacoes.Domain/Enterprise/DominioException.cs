namespace SistemaNacoes.Domain.Enterprise;

public class DominioException : NacoesAppException
{
    private const string Mensagem = "Não atendeu as regras do domínio";
    
    public DominioException(string? message = Mensagem) : base(message)
    {
    }
}