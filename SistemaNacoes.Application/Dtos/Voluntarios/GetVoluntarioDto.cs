using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Voluntarios;

public class GetVoluntarioDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    
    [JsonPropertyName("ChaveAcesso")]
    public Guid ChaveAcesso { get; set; }
    
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