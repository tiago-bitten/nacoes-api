using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Grupos;

public class VinculateVoluntarioGrupoDto
{
    [JsonPropertyName("GrupoId")]
    public int GrupoId { get; set; }
    
    [JsonPropertyName("VoluntarioId")]
    public int VoluntarioId { get; set; }
}