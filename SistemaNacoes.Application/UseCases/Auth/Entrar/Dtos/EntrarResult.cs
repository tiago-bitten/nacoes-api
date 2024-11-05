using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Auth.Entrar.Dtos;

public class EntrarResult : Result
{
    [JsonPropertyName("AccessToken")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("RefreshToken")]
    public string RefreshToken { get; set; }
}