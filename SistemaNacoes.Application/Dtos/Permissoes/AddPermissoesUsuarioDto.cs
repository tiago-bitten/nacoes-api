﻿using System.Text.Json.Serialization;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Application.Dtos.Permissoes;

public class AddPermissoesUsuarioDto
{
    [JsonPropertyName("UsuarioId")]
    public int UsuarioId { get; set; }
    
    [JsonPropertyName("Permissoes")]
    public List<EPermissoes> Permissoes { get; set; }
}