namespace SistemaNacoes.Application.Dtos.DataIndisponiveis;

public class CreateDataIndisponivelDto
{
    public Guid VoluntarioChaveAcesso { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFinal { get; set; }
    public string? Motivo { get; set; }
}