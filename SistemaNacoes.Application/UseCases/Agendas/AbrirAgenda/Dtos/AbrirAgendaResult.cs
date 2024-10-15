using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Agendas.AbrirAgenda.Dtos;

public class AbrirAgendaResult : Result
{
    [JsonPropertyName("AgendaId")]
    public int AgendaId { get; set; }
}