using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Grupos.CriarGrupo.Dtos;

public class CriarGrupoResult : Result
{
    [JsonPropertyName("GrupoId")]
    public int GrupoId { get; set; }
}