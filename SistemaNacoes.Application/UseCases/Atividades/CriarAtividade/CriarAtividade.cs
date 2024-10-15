using AutoMapper;
using SistemaNacoes.Application.UseCases.Atividades.CriarAtividade.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Atividades.CriarAtividade;

public class CriarAtividade : ICriarAtividadeUseCase
{
    private readonly IAtividadeService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IMinisterioService _ministerioService;

    public CriarAtividade(IAtividadeService service, IUnitOfWork uow, IMinisterioService ministerioService, IMapper mapper)
    {
        _service = service;
        _uow = uow;
        _ministerioService = ministerioService;
        _mapper = mapper;
    }

    public async Task<CriarAtividadeResult> ExecutarAsync(CriarAtividadeRequest request)
    {
        var ministerio = await _ministerioService.RecuperaGaranteExisteAsync(request.MinisterioId);
        
        var atividade = _mapper.Map<Atividade>(request);
        
        atividade.Ministerio = ministerio;

        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarAsync(atividade);
        await _uow.CommitTransacaoAsync();
        
        var result = _mapper.Map<CriarAtividadeResult>(atividade);
        
        return result;
    }
}