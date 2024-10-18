using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios.CriarVoluntarioMinisterio.Dtos;

public class CriarVoluntarioMinisterioResult : Result
{
    [JsonPropertyName("VoluntarioMinisteriosId")]
    public List<int> VoluntarioMinisteriosId { get; set; }
}