using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Agendamentos;

public class CreateAgendamentoDto
{
    [JsonPropertyName("VoluntarioId")]
    public int VoluntarioId { get; set; }
    
    [JsonPropertyName("MinisterioId")]
    public int MinisterioId { get; set; }
    
    [JsonPropertyName("AgendaId")]
    public int AgendaId { get; set; }
    
    [JsonPropertyName("AtividadeIds")]
    public List<int>? AtividadeIds { get; set; }
}