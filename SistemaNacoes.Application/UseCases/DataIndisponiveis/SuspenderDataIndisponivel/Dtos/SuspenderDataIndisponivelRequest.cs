using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis.SuspenderDataIndisponivel.Dtos;

public class SuspenderDataIndisponivelRequest : Request
{
    [JsonPropertyName("DataIndisponivelId")]
    public int DataIndisponivelId { get; set; }
}