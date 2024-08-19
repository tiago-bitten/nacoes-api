using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Outros;

public class GetMotivoIndisponibilidadeDto
{
    [JsonPropertyName("Motivo")]
    public string? Motivo { get; set; }
}