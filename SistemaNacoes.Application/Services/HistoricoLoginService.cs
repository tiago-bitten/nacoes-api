using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class HistoricoLoginService : IHistoricoLoginService
{
    #region Ctor
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IHistoricoLoginRepository _repository;

    public HistoricoLoginService(IUnitOfWork uow,
                                 IAmbienteUsuarioService ambienteUsuarioService,
                                 IHistoricoLoginRepository repository)
    {
        _uow = uow;
        _ambienteUsuarioService = ambienteUsuarioService;
        _repository = repository;
    }
    #endregion

    public async Task RealizarTentativaAsync(HistoricoLogin registroLogin)
    {
        await _repository.AdicionarAsync(registroLogin);
    }

    public async Task SucessoAsync(int usuarioId)
    {
        var ip = _ambienteUsuarioService.RecuperaUsuarioIp();
        var userAgent = _ambienteUsuarioService.RecuperaUsuarioUserAgent();
        var registroLogin = new HistoricoLogin
        {
            Sucesso = true,
            UsuarioId = usuarioId,
            Ip = ip,
            UserAgent = userAgent

        };
        await RealizarTentativaAsync(registroLogin);
    }

    public async Task NegadoAsync(int? usuarioId, EMotivoLoginAcessoNegado motivo)
    {
        var ip = _ambienteUsuarioService.RecuperaUsuarioIp();
        var userAgent = _ambienteUsuarioService.RecuperaUsuarioUserAgent();
        
        var registroLogin = new HistoricoLogin();
        
        registroLogin.UsuarioId = usuarioId;
        registroLogin.Ip = ip;
        registroLogin.UserAgent = userAgent;
        registroLogin.Motivo = motivo;
        registroLogin.Sucesso = false;
        
        await RealizarTentativaAsync(registroLogin);
    }
}