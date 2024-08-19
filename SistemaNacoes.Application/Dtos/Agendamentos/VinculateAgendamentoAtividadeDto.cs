using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Agendamentos;

public class VinculateAgendamentoAtividadeDto
{
    [JsonPropertyName("AtividadeId")]
    public int AtividadeId { get; set; }
    
    [JsonPropertyName("AgendamentoId")]
    public int AgendamentoId { get; set; }
}