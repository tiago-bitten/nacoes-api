using AutoMapper;
using SistemaNacoes.Application.UseCases.Atividades.CriarAtividade.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Atividade;
using SistemaNacoes.Domain.Entidades.HistoricoEntidade;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Atividades.CriarAtividade;

public class CriarAtividade : ICriarAtividadeUseCase
{
    private readonly IAtividadeService _service;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IMinisterioService _ministerioService;
    private readonly IPermissoesService _permissoesService;
    private readonly IHistoricoEntidadeService _historicoService;

    public CriarAtividade(IAtividadeService service, IUnitOfWork uow, IMinisterioService ministerioService, IMapper mapper, IPermissoesService permissoesService, IHistoricoEntidadeService historicoService)
    {
        _service = service;
        _uow = uow;
        _ministerioService = ministerioService;
        _mapper = mapper;
        _permissoesService = permissoesService;
        _historicoService = historicoService;
    }

    public async Task<CriarAtividadeResult> ExecutarAsync(CriarAtividadeRequest request)
    {
        await _permissoesService.VerificaGarantePermissaoAsync(EPermissoes.CriarAtividade, "Você não tem permissão para criar uma atividade.");
        
        var ministerio = await _ministerioService.RecuperaGaranteExisteAsync(request.MinisterioId);
        
        var atividade = _mapper.Map<Atividade>(request);
        
        atividade.Ministerio = ministerio;

        await _uow.IniciarTransacaoAsync();
        await _service.AdicionarAsync(atividade);
        await _uow.CommitTransacaoAsync();

        await _uow.IniciarTransacaoAsync();
        await _historicoService.RegistrarAsync("atividades", atividade.Id, "Criou atividade.");
        await _uow.CommitTransacaoAsync();
        
        var result = _mapper.Map<CriarAtividadeResult>(atividade);
        
        return result;
    }
}