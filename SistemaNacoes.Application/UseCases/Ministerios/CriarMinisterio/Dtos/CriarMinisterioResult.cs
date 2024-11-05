using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Ministerios.CriarMinisterio.Dtos;

public class CriarMinisterioResult : Result
{
    [JsonPropertyName("MinisterioId")]
    public int MinisterioId { get; set; }
}