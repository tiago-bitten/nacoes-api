using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Atividades.CriarAtividade.Dtos;

public class CriarAtividadeRequest : Request
{
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("MaximoVoluntarios")]
    public int MaximoVoluntarios { get; set; }
    
    [JsonPropertyName("MinisterioId")]
    public int MinisterioId { get; set; }
}