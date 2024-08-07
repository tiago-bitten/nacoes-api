namespace SistemaNacoes.Application.Dtos.Agendas;

public class OpenAgendaDto
{
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFinal { get; set; }
}