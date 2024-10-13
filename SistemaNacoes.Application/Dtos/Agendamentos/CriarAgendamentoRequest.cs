using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Agendamentos;

public class CriarAgendamentoRequest : Request
{
    [JsonPropertyName("VoluntarioMinisterioId")]
    public int VoluntarioMinisterioId { get; set; }
    
    [JsonPropertyName("AgendaId")]
    public int AgendaId { get; set; }
    
    [JsonPropertyName("AtividadeIds")]
    public List<int>? AtividadeIds { get; set; }
}