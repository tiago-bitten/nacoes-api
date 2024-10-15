using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.GrupoVoluntarios.CriarGrupoVoluntario.Dtos;

public class CriarGrupoVoluntarioResult : Result
{
    [JsonPropertyName("GrupoVoluntarioIds")]
    public List<int> GrupoVoluntarioIds { get; set; }
}