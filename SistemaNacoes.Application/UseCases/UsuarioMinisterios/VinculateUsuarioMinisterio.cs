using SistemaNacoes.Application.Dtos.UsuarioMinisterios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.UsuarioMinisterios;

public class VinculateUsuarioMinisterio
{
    private readonly IUnitOfWork _uow;
    private readonly IServiceBase<Usuario> _usuarioService;
    private readonly IMinisterioService _ministerioService;

    public VinculateUsuarioMinisterio(IUnitOfWork uow, IServiceBase<Usuario> usuarioService, IMinisterioService ministerioService)
    {
        _uow = uow;
        _usuarioService = usuarioService;
        _ministerioService = ministerioService;
    }

    public async Task<RespostaBase<dynamic>> ExecuteAsync(VinculateUsuarioMinisterioDto dto)
    {
        var usuario = await _usuarioService.RecuperaGaranteExisteAsync(dto.UsuarioId);
        var ministerio = await _ministerioService.RecuperaGaranteExisteAsync(dto.MinisterioId);
        
        var existsUsuarioMinisterio = await _uow.UsuarioMinisterios
            .BuscarAsync(x => x.UsuarioId == usuario.Id 
                            && x.MinisterioId == ministerio.Id
                            && !x.Removido);

        if (existsUsuarioMinisterio != null)
            throw new Exception(MensagemErroConstant.UsuarioMinisterioJaCadastrado);

        var usuarioMinisterio = new UsuarioMinisterio(usuario, ministerio);
        
        await _uow.UsuarioMinisterios.AdicionarAsync(usuarioMinisterio);
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(
            RespostaBaseMensagem.VinculateUsuarioMinisterio);
        
        return respostaBase;
    }
}