using AutoMapper;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Grupos;

public class GetAllGrupos
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllGrupos(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RespostaBase<List<GetGrupoDto>>> ExecuteAsync(QueryParametro query)
    {
        var totalGrupos = _uow.Grupos
            .GetAll()
            .Count(x => !x.Removido);
        
        var grupos = _uow.Grupos
            .GetAll()
            .Where(x => !x.Removido)
            .OrderBy(x => x.Nome)
            .Skip(query.Skip)
            .Take(query.Take)
            .ToList();
        
        var gruposDto = _mapper.Map<List<GetGrupoDto>>(grupos);
        
        var respostaBase = new RespostaBase<List<GetGrupoDto>>(MensagemRepostasConstant.GetGrupos, gruposDto, totalGrupos);
        
        return respostaBase;
    }
}