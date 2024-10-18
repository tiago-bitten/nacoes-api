using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis.CriarDataIndisponivel.Dtos;

public class CriarDataIndisponivelResult : Result
{
    [JsonPropertyName("DataIndisponivelId")]
    public int DataIndisponivelId { get; set; }
}