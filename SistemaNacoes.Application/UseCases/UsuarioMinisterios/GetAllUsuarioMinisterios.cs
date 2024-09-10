using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.UsuarioMinisterios;
using SistemaNacoes.Application.Extensions;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.UsuarioMinisterios;

public class GetAllUsuarioMinisterios
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    
    public GetAllUsuarioMinisterios(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RespostaBase<List<GetUsuarioMinisterioDto>>> ExcecuteAsync(QueryParametro queryParametro)
    {
        var query = _uow.UsuarioMinisterios
            .GetAll()
            .WhereNotRemovido();

        var totalUsuarioMinisterios = await query.CountAsync();
        
        var usuarioMinisterios = await query
            .Skip(queryParametro.Skip)
            .Take(queryParametro.Take)
            .ToListAsync();
        
        var usuarioMinisteriosDto = _mapper.Map<List<GetUsuarioMinisterioDto>>(usuarioMinisterios);
        
        var respostaBase = new RespostaBase<List<GetUsuarioMinisterioDto>>(
            RespostaBaseMensagem.GetUsuarioMinisterios, usuarioMinisteriosDto, totalUsuarioMinisterios);
        
        return respostaBase;
    }
}