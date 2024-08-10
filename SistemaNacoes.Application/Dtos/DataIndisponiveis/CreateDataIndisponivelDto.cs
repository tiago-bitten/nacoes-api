using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.DataIndisponiveis;

public class CreateDataIndisponivelDto
{
    [JsonPropertyName("VoluntarioChaveAcesso")]
    public Guid VoluntarioChaveAcesso { get; set; }
    
    [JsonPropertyName("DataInicio")]
    public DateTime DataInicio { get; set; }
    
    [JsonPropertyName("DataFinal")]
    public DateTime DataFinal { get; set; }
    
    [JsonPropertyName("Motivo")]
    public string? Motivo { get; set; }
}