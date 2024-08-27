using AutoMapper;
using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Ministerios;

public class CreateMinisterio
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateMinisterio(
        IUnitOfWork uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<GetMinisterioDto>> ExecuteAsync(CreateMinisterioDto dto)
    {
        var existsMinisterio = await _uow.Ministerios
            .FindAsync(x => x.Nome.ToLower() == dto.Nome.ToLower() && !x.Removido);
        
        if (existsMinisterio != null)
            throw new Exception(MensagemErroConstant.MinisterioJaExiste);
        
        var ministerio = _mapper.Map<Ministerio>(dto);
        
        await _uow.Ministerios.AddAsync(ministerio);
        await _uow.CommitAsync();
        
        var ministerioDto = _mapper.Map<GetMinisterioDto>(ministerio);

        var respostaBase = new RespostaBase<GetMinisterioDto>(
            MensagemRepostaConstant.CreateMinisterio, ministerioDto);

        return respostaBase;
    }
}