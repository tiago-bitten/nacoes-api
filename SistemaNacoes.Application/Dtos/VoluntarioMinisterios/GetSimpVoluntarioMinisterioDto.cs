using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Dtos.Voluntarios;

namespace SistemaNacoes.Application.Dtos.VoluntarioMinisterios;

public class GetSimpVoluntarioMinisterioDto
{
    [JsonPropertyName("Voluntario")]
    public GetSimpVoluntarioDto Voluntario { get; set; }
    
    [JsonPropertyName("Ministerio")]
    public GetMinisterioDto Ministerio { get; set; }
}