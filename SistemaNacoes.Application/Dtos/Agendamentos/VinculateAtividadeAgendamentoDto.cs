using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Agendamentos;

public class VinculateAtividadeAgendamentoDto
{
    [JsonPropertyName("AtividadeId")]
    public int AtividadeId { get; set; }
    
    [JsonPropertyName("AgendamentoId")]
    public int AgendamentoId { get; set; }
}