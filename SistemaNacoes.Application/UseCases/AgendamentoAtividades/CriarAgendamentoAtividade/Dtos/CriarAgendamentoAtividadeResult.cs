using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.AgendamentoAtividades.CriarAgendamentoAtividade.Dtos;

public class CriarAgendamentoAtividadeResult : Result
{
    [JsonPropertyName("AgendamentoAtividadeId")]
    public int AgendamentoAtividadeId { get; set; }
}