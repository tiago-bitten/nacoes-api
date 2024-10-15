using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;

public class CriarAgendamentoResult : Result
{
    [JsonPropertyName("AgendamentoId")]
    public int AgendamentoId { get; set; }
}