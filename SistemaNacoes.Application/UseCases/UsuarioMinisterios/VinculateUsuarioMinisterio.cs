using SistemaNacoes.Application.Dtos.UsuarioMinisterios;
using SistemaNacoes.Application.Responses;
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
        var usuario = await _usuarioService.GetAndEnsureExistsAsync(dto.UsuarioId);
        var ministerio = await _ministerioService.GetAndEnsureExistsAsync(dto.MinisterioId);
        
        var existsUsuarioMinisterio = await _uow.UsuarioMinisterios
            .FindAsync(x => x.UsuarioId == usuario.Id 
                            && x.MinisterioId == ministerio.Id
                            && x.Ativo);

        if (existsUsuarioMinisterio != null)
            throw new Exception(MensagemErrosConstant.UsuarioMinisterioJaCadastrado);

        var usuarioMinisterio = new UsuarioMinisterio(usuario, ministerio);
        
        await _uow.UsuarioMinisterios.AddAsync(usuarioMinisterio);
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(
            MensagemRepostasConstant.VinculateUsuarioMinisterio);
        
        return respostaBase;
    }
}