using AutoMapper;
using SistemaNacoes.Application.Dtos.DataIndisponiveis;
using SistemaNacoes.Application.Responses;
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
        var totalDataIndisponiveis = _uow.DataIndisponiveis
            .GetAll()
            .Count(x => !x.Removido && !x.Suspenso);
        
        var dataIndisponiveis = _uow.DataIndisponiveis
            .GetAll()
            .Where(x => !x.Removido && !x.Suspenso)
            .ToList();
        
        var dataIndisponiveisDto = _mapper.Map<List<GetDataIndisponivelDto>>(dataIndisponiveis);

        var respostaBase = new RespostaBase<List<GetDataIndisponivelDto>>(MensagemRepostasConstant.GetDataIndisponiveis, dataIndisponiveisDto, totalDataIndisponiveis);

        return respostaBase;
    }
}