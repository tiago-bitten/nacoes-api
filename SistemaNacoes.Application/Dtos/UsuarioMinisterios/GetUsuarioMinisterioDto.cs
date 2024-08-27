using System.Text.Json.Serialization;
using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Dtos.Usuarios;

namespace SistemaNacoes.Application.Dtos.UsuarioMinisterios;

public class GetUsuarioMinisterioDto
{
    [JsonPropertyName("Usuario")]
    public GetSimpUsuarioDto Usuario { get; set; }
    
    [JsonPropertyName("Ministerio")]
    public GetMinisterioDto Ministerio { get; set; }
}