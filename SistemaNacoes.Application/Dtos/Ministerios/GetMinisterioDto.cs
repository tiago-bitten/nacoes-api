using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Ministerios;

public class GetMinisterioDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("Descricao")]
    public string? Descricao { get; set; }
    
    [JsonPropertyName("Cor")]
    public string Cor { get; set; }
}