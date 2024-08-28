using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class AmbienteUsuarioService : IAmbienteUsuarioService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IServiceBase<Usuario> _usuarioService;
    
    public AmbienteUsuarioService(IHttpContextAccessor httpContextAccessor, IServiceBase<Usuario> usuarioService)
    {
        _httpContextAccessor = httpContextAccessor;
        _usuarioService = usuarioService;
    }

    public async Task<Usuario> GetUsuarioAsync()
    {
        var principal = _httpContextAccessor.HttpContext.User;

        var usuarioId = int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
        var usuario = await _usuarioService.GetAndEnsureExistsAsync(usuarioId);
        
        return usuario;
    }

    public string GetUsuarioIp()
    {
        return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
    }

    public string GetUsuarioUserAgent()
    {
        return _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
    }
}