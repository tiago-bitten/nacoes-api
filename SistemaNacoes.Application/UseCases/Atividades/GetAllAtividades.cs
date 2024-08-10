using AutoMapper;
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
        var atividades = _uow.Atividades.GetAll()
            .Skip(query.Skip)
            .Take(query.Take)
            .ToList();
        
        var atividadesDto = _mapper.Map<List<GetAtividadeDto>>(atividades);
        
        var respostaBase = new RespostaBase<List<GetAtividadeDto>>(MensagemRepostasConstant.GetAtividades, atividadesDto);
        
        return respostaBase;
    }
}