using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Dtos.Voluntarios;

namespace SistemaNacoes.Application.Dtos.GrupoVoluntarios;

public class GetVoluntariosNoGrupoDto
{
    [JsonPropertyName("Grupo")]
    public GetGrupoDto Grupo { get; set; }
    
    [JsonPropertyName("Voluntarios")]
    public List<GetSimpVoluntarioDto> Voluntarios { get; set; }
}