using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Auth;

public class LoginDto
{
    [JsonPropertyName("Email")]
    public string Email { get; set; }
    
    [JsonPropertyName("Senha")]
    public string Senha { get; set; }
}