using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios.ListarVoluntarioMinisterio.Dtos;

public class ListarVoluntarioMinisterioResult : Result
{
    [JsonPropertyName("VoluntarioMinisterioId")]
    public int VoluntarioMinisterioId { get; set; }
}