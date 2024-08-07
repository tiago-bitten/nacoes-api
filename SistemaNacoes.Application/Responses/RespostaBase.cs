using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Responses;

public class RespostaBase<T> where T : class
{
    public RespostaBase()
    {
    }
    public RespostaBase(string mensagem, T conteudo)
    {
        Sucesso = true;
        Mensagem = mensagem;
        Conteudo = conteudo;
    }
    
    public RespostaBase(string mensagem, T conteudo, int total)
    {
        Sucesso = true;
        Mensagem = mensagem;
        Conteudo = conteudo;
        Total = total;
    }
    
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