using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Agendas.ListarAgenda.Dto;

public class ListarAgendaResult : Result
{
    [JsonPropertyName("AgendaId")]
    public int AgendaId { get; set; }
    
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("DataInicio")]
    public DateTime DataInicio { get; set; }
    
    [JsonPropertyName("DataFinal")]
    public DateTime DataFinal { get; set; }
    
    [JsonPropertyName("TotalAgendamentos")]
    public int TotalAgendamentos { get; set; }
}