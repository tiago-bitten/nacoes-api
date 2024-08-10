using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.VoluntarioMinisterios;

public class VinculateVoluntarioMinisterioDto
{
    [JsonPropertyName("VoluntarioId")]
    public int VoluntarioId { get; set; }
    
    [JsonPropertyName("MinisterioId")]
    public int MinisterioId { get; set; }
}