﻿using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Auth;

public class RefreshAuthTokenDto
{
    [JsonPropertyName("AccessToken")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("RefreshToken_old")]
    public string RefreshToken { get; set; }
}