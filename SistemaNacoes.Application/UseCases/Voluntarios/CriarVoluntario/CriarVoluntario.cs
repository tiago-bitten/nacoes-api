using AutoMapper;
using SistemaNacoes.Application.UseCases.Voluntarios.CriarVoluntario.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Voluntarios.CriarVoluntario;

public class CriarVoluntario : ICriarVoluntarioUseCase
{
    #region Ctor
    private readonly IVoluntarioService _service;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;

    public CriarVoluntario(IVoluntarioService service, IMapper mapper, IUnitOfWork uow, IPermissoesService permissoesService, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _mapper = mapper;
        _uow = uow;
        _permissoesService = permissoesService;
        _historicoService = historicoService;
    }
    #endregion
    
    public async Task<CriarVoluntarioResult> ExecutarAsync(CriarVoluntarioRequest request)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CriarVoluntario, "Você não tem permissão para criar um voluntário");

        await _service.GaranteNaoExisteCadastradoAsync(request.Cpf);
        
        var voluntario = _mapper.Map<Voluntario>(request);

        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarAsync(voluntario);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("voluntarios", voluntario.Id, "Voluntário criado.");
        await _uow.CommitTransacaoAsync();
        
        var result = _mapper.Map<CriarVoluntarioResult>(voluntario);
        
        return result;
    }
}