using System.Text.Json.Serialization;

namespace SistemaNacoes.Shared.Resposta;

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

    [JsonPropertyName("TemProximo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? TemProximo { get; set; }

    [JsonPropertyName("TemAnterior")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? TemAnterior { get; set; }

    public static RespostaBase<T> SucessoComConteudo(T conteudo, string? mensagem = null)
    {
        return new RespostaBase<T>
        {
            Sucesso = true,
            Mensagem = mensagem,
            Conteudo = conteudo
        };
    }

    public static RespostaBase<T> Erro(string mensagem)
    {
        return new RespostaBase<T>
        {
            Sucesso = false,
            Mensagem = mensagem
        };
    }

    public static RespostaBase<T> ComPaginacao(T conteudo, int total, bool temProximo, bool temAnterior, string? mensagem = null)
    {
        return new RespostaBase<T>
        {
            Sucesso = true,
            Mensagem = mensagem,
            Conteudo = conteudo,
            Total = total,
            TemProximo = temProximo,
            TemAnterior = temAnterior
        };
    }
    
    public static RespostaBase<T> SucessoBase(string? mensagem = null)
    {
        return new RespostaBase<T>
        {
            Sucesso = true,
            Mensagem = mensagem
        };
    }
}
