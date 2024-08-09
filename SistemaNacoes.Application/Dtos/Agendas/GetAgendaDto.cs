namespace SistemaNacoes.Application.Dtos.Agendas;

public class GetAgendaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFinal { get; set; }
    public bool Finalizado { get; set; }
}