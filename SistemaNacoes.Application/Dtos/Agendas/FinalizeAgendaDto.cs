using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Agendas;

public class FinalizeAgendaDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
}