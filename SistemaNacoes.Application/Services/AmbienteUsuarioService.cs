﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Entidades.Usuario;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Extensions;

namespace SistemaNacoes.Application.Services;

public class AmbienteUsuarioService : IAmbienteUsuarioService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUsuarioService _usuarioService;
    
    public AmbienteUsuarioService(IHttpContextAccessor httpContextAccessor, IUsuarioService usuarioService)
    {
        _httpContextAccessor = httpContextAccessor;
        _usuarioService = usuarioService;
    }

    public async Task<Usuario> RecuperaUsuarioAsync(params string[]? includes)
    {
        var usuario = await _usuarioService.RecuperaGaranteExisteAsync(RecuperaUsuarioId(), includes);
        
        return usuario;
    }

    public string? RecuperaUsuarioIp()
    {
        return _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
    }

    public string? RecuperaUsuarioUserAgent()
    {
        return _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"];
    }

    public int RecuperaUsuarioId()
    {
        var principal = _httpContextAccessor.HttpContext?.User;
        var usuarioId = principal?.RecuperarNameIdentifier();

        return usuarioId ?? 0;
    }

    public List<string>? RecuperaUsuarioRoles()
    {
        var principal = _httpContextAccessor.HttpContext?.User;
        return principal?.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
    }

    public string? RecuperaUsuarioNome()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
    }

    public string? RecuperaUsuarioEmail()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
    }

    public bool Autenticado()
    {
        return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
