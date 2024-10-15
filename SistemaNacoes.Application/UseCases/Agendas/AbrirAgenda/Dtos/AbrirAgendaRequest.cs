using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Agendas.AbrirAgenda.Dtos;

public class AbrirAgendaRequest : Request
{
    [JsonPropertyName("Titulo")]
    public string Titulo { get; set; }
    
    [JsonPropertyName("Descricao")]
    public string? Descricao { get; set; }
    
    [JsonPropertyName("DataInicio")]
    public DateTime DataInicio { get; set; }
    
    [JsonPropertyName("Duracao")]
    public int Duracao { get; set; } = 60;
}