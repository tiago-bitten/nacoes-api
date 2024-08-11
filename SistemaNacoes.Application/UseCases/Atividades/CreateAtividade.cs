using AutoMapper;
using SistemaNacoes.Application.Dtos.Atividades;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Atividades;

public class CreateAtividade
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IServiceBase<Ministerio> _ministerioService;

    public CreateAtividade(IUnitOfWork uow, IMapper mapper, IServiceBase<Ministerio> ministerioService)
    {
        _uow = uow;
        _mapper = mapper;
        _ministerioService = ministerioService;
    }
    
    public async Task<RespostaBase<GetAtividadeDto>> ExecuteAsync(CreateAtividadeDto dto)
    {
        var ministerio = await _ministerioService.GetAndEnsureExistsAsync(dto.MinisterioId);
        
        var atividade = _mapper.Map<Atividade>(dto);

        atividade.Ministerio = ministerio;
        
        await _uow.Atividades.AddAsync(atividade);
        await _uow.CommitAsync();
        
        var atividadeDto = _mapper.Map<GetAtividadeDto>(atividade);
        
        var respostaBase = new RespostaBase<GetAtividadeDto>(MensagemRepostasConstant.CreateAtividade, atividadeDto);
        
        return respostaBase;
    }
}