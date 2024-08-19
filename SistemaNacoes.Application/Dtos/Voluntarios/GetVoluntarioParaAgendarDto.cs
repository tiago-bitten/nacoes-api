using System.Text.Json.Serialization;
using SistemaNacoes.Application.UseCases.Voluntarios;

namespace SistemaNacoes.Application.Dtos.Voluntarios;

public class GetVoluntarioParaAgendarDto
{
    [JsonPropertyName("Voluntario")]
    public GetSimpVoluntarioDto Voluntario;
    
    [JsonPropertyName("Disponivel")]
    public bool Disponivel;
    
    [JsonPropertyName("MotivoIndisponibilidades")]
    public List<GetMotivoIndisponibilidadeDto> MotivoIndisponibilidades;
}