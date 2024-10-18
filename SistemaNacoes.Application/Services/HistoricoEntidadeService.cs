using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class HistoricoEntidadeService : IHistoricoEntidadeService
{
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    
    public HistoricoEntidadeService(IUnitOfWork uow, IAmbienteUsuarioService ambienteUsuarioService)
    {
        _uow = uow;
        _ambienteUsuarioService = ambienteUsuarioService;
    }

    public async Task RegistrarAsync(string tabela, int itemId, string descricao)
    {
        var usuario = await _ambienteUsuarioService.RecuperaUsuarioAsync();
        var ip = _ambienteUsuarioService.RecuperaUsuarioIp();
        var userAgent = _ambienteUsuarioService.RecuperaUsuarioUserAgent();
        
        var registroCriacao = new HistoricoEntidade(tabela, itemId, usuario.Id, ip, userAgent, descricao);

        await _uow.RegistroCriacoes.AddAsync(registroCriacao);
    }
    
    public async Task RegistrarVariosAsync(string tabela, IEnumerable<int> itemIds, string descricao)
    {
        var usuario = await _ambienteUsuarioService.RecuperaUsuarioAsync();
        var ip = _ambienteUsuarioService.RecuperaUsuarioIp();
        var userAgent = _ambienteUsuarioService.RecuperaUsuarioUserAgent();
        
        var registroCriacoes = itemIds
            .Select(itemId => new HistoricoEntidade(tabela, itemId, usuario.Id, ip, userAgent, descricao));

        await _uow.RegistroCriacoes.AddRangeAsync(registroCriacoes);
    }
}