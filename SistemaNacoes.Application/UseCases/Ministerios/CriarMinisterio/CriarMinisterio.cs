using AutoMapper;
using SistemaNacoes.Application.UseCases.Ministerios.CriarMinisterio.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Ministerios.CriarMinisterio;

public class CriarMinisterio : ICriarMinisterioUseCase
{
    private readonly IMinisterioService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IHistoricoEntidadeService _historicoService;
    private readonly IPermissoesService _permissoesService;
    
    public CriarMinisterio(IMinisterioService service, IUnitOfWork uow, IMapper mapper, IHistoricoEntidadeService historicoService, IPermissoesService permissoesService)
    {
        _service = service;
        _uow = uow;
        _mapper = mapper;
        _historicoService = historicoService;
        _permissoesService = permissoesService;
    }

    public async Task<CriarMinisterioResult> ExecutarAsync(CriarMinisterioRequest request)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CriarMinisterio, "Você não possui permissão para criar ministérios");
        
        var ministerio = _mapper.Map<Ministerio>(request);
        
        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarAsync(ministerio);
        await _uow.CommitTransacaoAsync();
        
        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("ministerios", ministerio.Id, "Criou ministério.");
        await _uow.CommitTransacaoAsync();
        
        var result = _mapper.Map<CriarMinisterioResult>(ministerio);
        
        return result;
    }
}