using AutoMapper;
using SistemaNacoes.Application.UseCases.Usuarios.CriarUsuario.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Helpers;

namespace SistemaNacoes.Application.UseCases.Usuarios.CriarUsuario;

public class CriarUsuario : ICriarUsuarioUseCase
{
    #region Ctor
    private readonly IUsuarioService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;

    public CriarUsuario(IUsuarioService service, IUnitOfWork uow, IMapper mapper, IPermissoesService permissoesService, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _uow = uow;
        _mapper = mapper;
        _permissoesService = permissoesService;
        _historicoService = historicoService;
    }
    #endregion

    public async Task<CriarUsuarioResult> ExecutarAsync(CriarUsuarioRequest request)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CREATE_USUARIO,
            "Você não possui permissão para criar usuários.");

        await _service.GaranteNaoExisteUsuarioCriadoAsync(request.Email, request.Cpf);
        
        var usuario = _mapper.Map<Usuario>(request);

        usuario.SenhaHash = SenhaHelper.ProvisionarSenha(); // Data de hoje
        
        
    }
}