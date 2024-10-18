using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Voluntarios.ListarVoluntario.Dtos;

public class ListarVoluntarioResult : Result
{
    [JsonPropertyName("VoluntarioId")]
    public int VoluntarioId { get; set; }
    
    [JsonPropertyName("ChaveAcesso")]
    public Guid ChaveAcesso { get; set; }
    
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
}