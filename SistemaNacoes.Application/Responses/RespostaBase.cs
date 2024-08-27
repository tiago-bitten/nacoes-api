using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Responses;

public class RespostaBase<T> where T : class
{
    public RespostaBase()
    {
    }
    
    public RespostaBase(string mensagem)
    {
        Mensagem = mensagem;
    }
    
    public RespostaBase(string mensagem, T conteudo)
    {
        Mensagem = mensagem;
        Conteudo = conteudo;
    }
    
    public RespostaBase(string mensagem, T conteudo, int total)
    {
        Mensagem = mensagem;
        Conteudo = conteudo;
        Total = total;
    }

    [JsonPropertyName("Sucesso")] 
    public bool Sucesso { get; set; } = true;
    
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