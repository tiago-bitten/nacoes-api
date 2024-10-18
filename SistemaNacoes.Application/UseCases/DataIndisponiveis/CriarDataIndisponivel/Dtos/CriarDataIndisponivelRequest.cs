using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis.CriarDataIndisponivel.Dtos;

public class CriarDataIndisponivelRequest : Request
{
    [JsonPropertyName("VoluntarioChaveAcesso")]
    public string VoluntarioChaveAcesso { private get; set; }
    
    [JsonPropertyName("DataInicio")]
    public DateTime DataInicio { get; set; }
    
    [JsonPropertyName("DataFinal")]
    public DateTime DataFinal { get; set; }
    
    [JsonPropertyName("Motivo")]
    public string? Motivo { get; set; }
    
    [JsonIgnore]
    public Guid VoluntarioChaveAcessoGuid
    {
        get
        {
            if (Guid.TryParse(VoluntarioChaveAcesso, out var guid))
            {
                return guid;
            }

            throw new InvalidOperationException($"'{VoluntarioChaveAcesso}' não é um Guid válido.");
        }
    }
}