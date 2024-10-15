using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Atividades.CriarAtividade.Dtos;

public class CriarAtividadeRequest : Request
{
    [JsonPropertyName("AtividadeId")]
    public string Nome { get; set; }
    
    [JsonPropertyName("MinisterioId")]
    public int MinisterioId { get; set; }
}