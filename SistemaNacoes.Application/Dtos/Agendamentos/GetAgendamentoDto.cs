using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos.Atividades;
using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Dtos.VoluntarioMinisterios;
using SistemaNacoes.Application.Dtos.Voluntarios;

namespace SistemaNacoes.Application.Dtos.Agendamentos;

public class GetAgendamentoDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    
    [JsonPropertyName("Voluntario")]
    public GetSimpVoluntarioDto Voluntario { get; set; }
    
    [JsonPropertyName("Ministerio")]
    public GetMinisterioDto Ministerio { get; set; }
    
    [JsonPropertyName("Atividades")]
    public List<GetSimpAtividadeDto>? Atividades { get; set; }
}