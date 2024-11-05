using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Voluntarios.CriarVoluntario.Dtos;

public class CriarVoluntarioRequest : Request
{
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("Email")]
    public string Email { get; set; }
    
    [JsonPropertyName("Cpf")]
    public string? Cpf { get; set; }
    
    [JsonPropertyName("Celular")]
    public string? Celular { get; set; }
    
    [JsonPropertyName("DataNascimento")]
    public DateTime? DataNascimento { get; set; }
}