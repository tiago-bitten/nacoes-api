using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.SituacaoAgendamentos;

public class GetSituacaoAgendamentoDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    
    [JsonPropertyName("Ativo")]
    public bool Ativo { get; set; }
    
    [JsonPropertyName("Descricao")]
    public string? Descricao { get; set; }
}