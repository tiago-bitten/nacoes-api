using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Domain.Entidades.HistoricoEntidade;

public class HistoricoEntidadeService : IHistoricoEntidadeService
{
    private readonly IHistoricoEntidadeRepository _repository;
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    
    public HistoricoEntidadeService(IUnitOfWork uow, IAmbienteUsuarioService ambienteUsuarioService, IHistoricoEntidadeRepository repository)
    {
        _uow = uow;
        _ambienteUsuarioService = ambienteUsuarioService;
        _repository = repository;
    }

    public async Task RegistrarAsync(string tabela, int itemId, string descricao)
    {
        var usuario = await _ambienteUsuarioService.RecuperaUsuarioAsync();
        var ip = _ambienteUsuarioService.RecuperaUsuarioIp();
        var userAgent = _ambienteUsuarioService.RecuperaUsuarioUserAgent();
        
        var registroCriacao = new HistoricoEntidade(tabela, itemId, usuario.Id, ip, userAgent, descricao);

        await _repository.AdicionarAsync(registroCriacao);
    }
    
    public async Task RegistrarVariosAsync(string tabela, IEnumerable<int> itemIds, string descricao)
    {
        var usuario = await _ambienteUsuarioService.RecuperaUsuarioAsync();
        var ip = _ambienteUsuarioService.RecuperaUsuarioIp();
        var userAgent = _ambienteUsuarioService.RecuperaUsuarioUserAgent();
        
        var registroCriacoes = itemIds
            .Select(itemId => new HistoricoEntidade(tabela, itemId, usuario.Id, ip, userAgent, descricao));

        await _repository.AdicionarVariosAsync(registroCriacoes);
    }
}