using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Voluntario;
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
    public List<EMotivoIndisponibilidadeAgendamento?> MotivoIndisponibilidades { get; private set; } = new();

    public static RecuperarVoluntarioParaAgendarResult Criar(Voluntario voluntario)
    {
        return new RecuperarVoluntarioParaAgendarResult
        {
            VoluntarioId = voluntario.Id,
            Nome = voluntario.Nome
        };
    }
}