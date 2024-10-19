using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Application.UseCases.Voluntarios.RecuperarVoluntarioParaAgendar.Dtos;

public class RecuperarVoluntarioParaAgendarResult : Result
{
    [JsonPropertyName("VoluntarioId")]
    public int VoluntarioId { get; set; }
    
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("Disponivel")]
    public bool Disponivel => MotivoIndisponibilidades.Count == 0;

    [JsonPropertyName("MotivoIndisponibilidades")]
    public List<EMotivoIndisponibilidadeAgendamento?> MotivoIndisponibilidades { get; set; } = new();
}