using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.UseCases.Voluntarios;

public class GetMotivoIndisponibilidadeDto
{
    [JsonPropertyName("Motivo")]
    public string Motivo { get; set; }
}