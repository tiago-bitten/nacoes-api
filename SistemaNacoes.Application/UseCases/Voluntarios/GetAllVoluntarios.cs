using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Voluntarios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Voluntarios;

public class GetAllVoluntarios
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllVoluntarios(
        IUnitOfWork uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RespostaBase<List<GetVoluntarioDto>>> ExecuteAsync(QueryParametro query)
    {
        var totalVoluntarios = await _uow.Voluntarios
            .GetAll()
            .CountAsync(x => !x.Removido);
        
        var voluntarios = await _uow.Voluntarios
            .GetAll()
            .Where(x => !x.Removido)
            .Skip(query.Skip)
            .Take(query.Take)
            .ToListAsync();
        
        var voluntariosDto = _mapper.Map<List<GetVoluntarioDto>>(voluntarios);
        
        var respostaBase = new RespostaBase<List<GetVoluntarioDto>>(
            MensagemRepostasConstant.GetVoluntarios, voluntariosDto, totalVoluntarios);
        
        return respostaBase;
    }
}