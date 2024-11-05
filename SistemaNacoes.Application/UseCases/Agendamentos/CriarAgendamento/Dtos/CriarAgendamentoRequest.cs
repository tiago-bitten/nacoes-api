using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;

public class CriarAgendamentoRequest : Request
{
    [JsonPropertyName("VoluntarioId")]
    public int VoluntarioId { get; set; }
    
    [JsonPropertyName("MinisterioId")]
    public int MinisterioId { get; set; }
    
    [JsonPropertyName("AgendaId")]
    public int AgendaId { get; set; }
}