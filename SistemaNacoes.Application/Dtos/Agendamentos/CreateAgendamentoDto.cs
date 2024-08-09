namespace SistemaNacoes.Application.Dtos.Agendamentos;

public class CreateAgendamentoDto
{
    public int VoluntarioId { get; set; }
    public int MinisterioId { get; set; }
    public int AgendaId { get; set; }
    public List<int> AtividadeIds { get; set; }
}