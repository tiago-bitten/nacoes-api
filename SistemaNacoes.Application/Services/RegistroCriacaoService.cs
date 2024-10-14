using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class RegistroCriacaoService : IRegistroCriacaoService
{
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    
    public RegistroCriacaoService(IUnitOfWork uow, IAmbienteUsuarioService ambienteUsuarioService)
    {
        _uow = uow;
        _ambienteUsuarioService = ambienteUsuarioService;
    }

    public async Task LogAsync(string tabela, int itemId)
    {
        var usuario = await _ambienteUsuarioService.RecuperaUsuarioAsync();
        var ip = _ambienteUsuarioService.RecuperaUsuarioIp();
        var userAgent = _ambienteUsuarioService.RecuperaUsuarioUserAgent();
        
        var registroCriacao = new RegistroCriacao(tabela, itemId, usuario.Id, ip, userAgent);

        await _uow.RegistroCriacoes.AddAsync(registroCriacao);
    }
    
    public async Task LogRangeAsync(string tabela, IEnumerable<int> itemIds)
    {
        var usuario = await _ambienteUsuarioService.RecuperaUsuarioAsync();
        var ip = _ambienteUsuarioService.RecuperaUsuarioIp();
        var userAgent = _ambienteUsuarioService.RecuperaUsuarioUserAgent();
        
        var registroCriacoes = itemIds
            .Select(itemId => new RegistroCriacao(tabela, itemId, usuario.Id, ip, userAgent));

        await _uow.RegistroCriacoes.AddRangeAsync(registroCriacoes);
    }
}