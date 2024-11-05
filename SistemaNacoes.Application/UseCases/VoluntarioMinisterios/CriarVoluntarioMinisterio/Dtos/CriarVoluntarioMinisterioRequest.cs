using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios.CriarVoluntarioMinisterio.Dtos;

public class CriarVoluntarioMinisterioRequest : Request
{
    [JsonPropertyName("VoluntarioId")]
    public int VoluntarioId { get; set; }
    
    [JsonPropertyName("MinisteriosId")]
    public List<int> MinisteriosId { get; set; }
}