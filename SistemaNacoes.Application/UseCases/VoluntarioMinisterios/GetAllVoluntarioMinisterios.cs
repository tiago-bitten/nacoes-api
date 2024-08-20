﻿using AutoMapper;
using SistemaNacoes.Application.Dtos.VoluntarioMinisterios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios;

public class GetAllVoluntarioMinisterios
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllVoluntarioMinisterios(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<List<GetSimpVoluntarioMinisterioDto>>> ExecuteAsync(QueryParametro query)
    {
        var includes = new[] { "Voluntario", "Ministerio" };
        
        var totalVoluntarioMinisterios = _uow.VoluntarioMinisterios
            .GetAll(includes)
            .Count(x => x.Ativo);
        
        var voluntarioMinisterios = _uow.VoluntarioMinisterios
            .GetAll(includes)
            .Where(x => x.Ativo)
            .Skip(query.Skip)
            .Take(query.Take)
            .ToList();
        
        var voluntarioMinisteriosDto = _mapper.Map<List<GetSimpVoluntarioMinisterioDto>>(voluntarioMinisterios);

        var respostaBase = new RespostaBase<List<GetSimpVoluntarioMinisterioDto>>(
            MensagemRepostasConstant.GetVoluntariosMinisterios, voluntarioMinisteriosDto, totalVoluntarioMinisterios);
        
        return respostaBase;
    }
}