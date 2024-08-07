using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Voluntarios;

public class CreateVoluntarioDto
{
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("Email")]
    public string Email { get; set; }
    
    [JsonPropertyName("Cpf")]
    public string? Cpf { get; set; }
    
    [JsonPropertyName("DataNascimento")]
    public DateTime? DataNascimento { get; set; }
}