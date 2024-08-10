using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Agendas;

public class OpenAgendaDto
{
    [JsonPropertyName("Titulo")]
    public string Titulo { get; set; }
    
    [JsonPropertyName("Descricao")]
    public string? Descricao { get; set; }
    
    [JsonPropertyName("DataInicio")]
    public DateTime DataInicio { get; set; }
    
    [JsonPropertyName("DataFinal")]
    public DateTime DataFinal { get; set; }
}