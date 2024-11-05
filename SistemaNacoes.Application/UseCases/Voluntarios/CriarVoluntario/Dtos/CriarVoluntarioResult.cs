using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Voluntarios.CriarVoluntario.Dtos;

public class CriarVoluntarioResult : Result
{
    [JsonPropertyName("VoluntarioId")]
    public int VoluntarioId { get; set; }
}