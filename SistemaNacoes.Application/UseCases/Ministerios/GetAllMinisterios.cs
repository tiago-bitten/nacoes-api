using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Ministerios;

public class GetAllMinisterios
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllMinisterios(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetMinisterioDto>>> ExecuteAsync(QueryParametro query)
    {
        var totalMinisterios = await _uow.Ministerios
            .GetAll()
            .CountAsync();
        
        var ministerios = await _uow.Ministerios.GetAll()
            .Skip(query.Skip)
            .Take(query.Take)
            .ToListAsync();
        
        var ministeriosDto = _mapper.Map<List<GetMinisterioDto>>(ministerios);
        
        var respostaBase = new RespostaBase<List<GetMinisterioDto>>(
            MensagemRepostasConstant.GetMinisterios, ministeriosDto, totalMinisterios);
        
        return respostaBase;
    }
}