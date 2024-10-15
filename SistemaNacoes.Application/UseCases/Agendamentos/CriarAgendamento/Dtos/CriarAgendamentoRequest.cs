using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;

public class CriarAgendamentoRequest : Request
{
    [JsonPropertyName("VoluntarioMinisterioId")]
    public int VoluntarioMinisterioId { get; set; }
    
    [JsonPropertyName("AgendaId")]
    public int AgendaId { get; set; }
}