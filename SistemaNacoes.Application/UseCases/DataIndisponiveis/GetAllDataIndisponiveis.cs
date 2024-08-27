using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.DataIndisponiveis;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis;

public class GetAllDataIndisponiveis
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllDataIndisponiveis(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetDataIndisponivelDto>>> ExecuteAsync()
    {
        var query = _uow.DataIndisponiveis
            .GetAll()
            .Where(GetCondicao());
        
        var totalDataIndisponiveis = await query.CountAsync();
        
        var dataIndisponiveis = await query.ToListAsync();
        
        var dataIndisponiveisDto = _mapper.Map<List<GetDataIndisponivelDto>>(dataIndisponiveis);

        var respostaBase = new RespostaBase<List<GetDataIndisponivelDto>>(
            MensagemRepostaConstant.GetDataIndisponiveis, dataIndisponiveisDto, totalDataIndisponiveis);

        return respostaBase;
    }
    
    private static Expression<Func<DataIndisponivel, bool>> GetCondicao()
    {
        return x => !x.Removido && !x.Suspenso;
    }
}