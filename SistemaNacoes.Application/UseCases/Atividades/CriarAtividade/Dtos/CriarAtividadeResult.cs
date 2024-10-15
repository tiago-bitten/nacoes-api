using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Atividades.CriarAtividade.Dtos;

public class CriarAtividadeResult : Result
{
    [JsonPropertyName("AtividadeId")]
    public int AtividadeId { get; set; }
}