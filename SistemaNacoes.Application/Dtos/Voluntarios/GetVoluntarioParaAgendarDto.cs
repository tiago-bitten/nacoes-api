using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos.Outros;

namespace SistemaNacoes.Application.Dtos.Voluntarios;

public class GetVoluntarioParaAgendarDto
{
    [JsonPropertyName("Voluntario")]
    public GetSimpVoluntarioDto Voluntario { get; set; }
    
    [JsonPropertyName("Disponivel")]
    public bool Disponivel { get; set; }
    
    [JsonPropertyName("MotivoIndisponibilidades")]
    public List<GetMotivoIndisponibilidadeDto>? MotivoIndisponibilidades { get; set; }
}