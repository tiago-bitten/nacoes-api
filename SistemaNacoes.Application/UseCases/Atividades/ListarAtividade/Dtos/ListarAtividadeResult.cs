using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Atividades.ListarAtividade.Dtos;

public class ListarAtividadeResult : Result
{
    [JsonPropertyName("AtividadeId")]
    public int AtividadeId { get; set; }
    
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("MaximoVoluntarios")]
    public int MaximoVoluntarios { get; set; }
    
    [JsonPropertyName("Ministerio")]
    public int Ministerio { get; set; }
}