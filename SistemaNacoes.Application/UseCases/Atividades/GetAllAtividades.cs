using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Atividades;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Atividades;

public class GetAllAtividades
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllAtividades(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetAtividadeDto>>> ExecuteAsync(QueryParametro query)
    {
        var totalAtividades = await _uow.Atividades
            .GetAll()
            .CountAsync(x => !x.Removido);
        
        var atividades = await _uow.Atividades
            .GetAll()
            .Where(x => !x.Removido)
            .Skip(query.Skip)
            .Take(query.Take)
            .ToListAsync();
        
        var atividadesDto = _mapper.Map<List<GetAtividadeDto>>(atividades);
        
        var respostaBase = new RespostaBase<List<GetAtividadeDto>>(MensagemRepostasConstant.GetAtividades, atividadesDto, totalAtividades);
        
        return respostaBase;
    }
}