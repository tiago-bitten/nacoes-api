using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Responses;

public class RespostaBase<T> where T : class
{
    [JsonPropertyName("Sucesso")]
    public bool Sucesso { get; set; }
    
    [JsonPropertyName("Mensagem")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Mensagem { get; set; }
    
    [JsonPropertyName("Conteudo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Conteudo { get; set; }
    
    [JsonPropertyName("Total")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Total { get; set; }
}