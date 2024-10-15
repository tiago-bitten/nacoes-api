using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.GrupoVoluntarios.CriarGrupoVoluntario.Dtos;

public class CriarGrupoVoluntarioRequest: Request
{
    [JsonPropertyName("GrupoId")]
    public int GrupoId { get; set; }
    
    [JsonPropertyName("VoluntarioIds")]
    public List<int> VoluntarioIds { get; set; }
}