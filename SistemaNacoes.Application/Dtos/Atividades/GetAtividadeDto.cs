using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Atividades;

public class GetAtividadeDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("MaximoVoluntarios")]
    public int MaximoVoluntarios { get; set; }
}