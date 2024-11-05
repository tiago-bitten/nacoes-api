using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Grupos.CriarGrupo.Dtos;

public class CriarGrupoRequest : Request
{
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("MinisterioPreferencialId")]
    public int? MinisterioPreferencialId { get; set; }
}