using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis.CriarDataIndisponivel.Dtos;

public class CriarDataIndisponivelRequest : Request
{
    [JsonPropertyName("VoluntarioChaveAcesso")]
    public string VoluntarioChaveAcesso { get; set; }
    
    [JsonPropertyName("DataInicio")]
    public DateTime DataInicio { get; set; }
    
    [JsonPropertyName("DataFinal")]
    public DateTime DataFinal { get; set; }
    
    [JsonPropertyName("Motivo")]
    public string? Motivo { get; set; }
}