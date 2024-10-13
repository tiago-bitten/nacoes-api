using AutoMapper;
using SistemaNacoes.Application.Dtos.Atividades;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Atividades;

public class CreateAtividade
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IServiceBase<Ministerio> _ministerioService;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IRegistroCriacaoService _registroCriacaoService;

    public CreateAtividade(IUnitOfWork uow, IMapper mapper, IServiceBase<Ministerio> ministerioService, IAmbienteUsuarioService ambienteUsuarioService, IRegistroCriacaoService registroCriacaoService)
    {
        _uow = uow;
        _mapper = mapper;
        _ministerioService = ministerioService;
        _ambienteUsuarioService = ambienteUsuarioService;
        _registroCriacaoService = registroCriacaoService;
    }
    
    public async Task<RespostaBase<GetAtividadeDto>> ExecuteAsync(CreateAtividadeDto dto)
    {
        var usuarioLogado = await _ambienteUsuarioService.GetUsuarioAsync();
        
        if (!usuarioLogado.HasPermission(EPermissoes.CREATE_ATIVIDADE))
            throw new Exception(MensagemErroConstant.SemPermissaoParaCriarAtividade);
        
        var ministerio = await _ministerioService.RecuperaGaranteExisteAsync(dto.MinisterioId);
        
        var atividade = _mapper.Map<Atividade>(dto);

        atividade.Ministerio = ministerio;
        
        await _uow.Atividades.AddAsync(atividade);
        await _uow.CommitAsync();
        
        await _registroCriacaoService.LogAsync("atividades", atividade.Id);
        
        var atividadeDto = _mapper.Map<GetAtividadeDto>(atividade);
        
        var respostaBase = new RespostaBase<GetAtividadeDto>(
            RespostaBaseMensagem.CreateAtividade, atividadeDto);
        
        return respostaBase;
    }
}