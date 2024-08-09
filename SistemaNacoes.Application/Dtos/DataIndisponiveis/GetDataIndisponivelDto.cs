namespace SistemaNacoes.Application.Dtos.DataIndisponiveis;

public class GetDataIndisponivelDto
{
    public int Id { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFinal { get; set; }
    public string? Motivo { get; set; }
}