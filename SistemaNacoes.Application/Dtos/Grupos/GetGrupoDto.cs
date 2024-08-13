using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos.Ministerios;

namespace SistemaNacoes.Application.Dtos.Grupos;

public class GetGrupoDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("MinisterioPrefencial")]
    public GetMinisterioDto MinisterioPrefencial { get; set; }
}