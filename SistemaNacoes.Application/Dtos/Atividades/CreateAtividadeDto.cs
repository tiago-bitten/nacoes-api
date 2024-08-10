using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Atividades;

public class CreateAtividadeDto
{
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("MaximoVoluntarios")]
    public int MaximoVoluntarios { get; set; }
    
    [JsonPropertyName("MinisterioId")]
    public int MinisterioId { get; set; }
}