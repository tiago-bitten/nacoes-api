using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Auth.Entrar.Dtos;

public class EntrarRequest : Request
{
    [JsonPropertyName("Email")]
    public string Email { get; set; }
    
    [JsonPropertyName("Senha")]
    public string Senha { get; set; }
}