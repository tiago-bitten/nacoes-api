using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Grupos;

public class CreateGrupoDto
{
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("MinisterioPreferencialId")]
    public int? MinisterioPreferencialId { get; set; }
    
    [JsonPropertyName("VoluntarioIds")]
    public List<int>? VoluntarioIds { get; set; }
}