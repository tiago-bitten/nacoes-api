using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Auth.RefreshToken.Dtos;

public class RefreshTokenRequest : Request
{
    [JsonPropertyName("AccessToken")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("RefreshToken_old")]
    public string RefreshToken { get; set; }
}