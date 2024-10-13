using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.UsuarioMinisterios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.UsuarioMinisterios;

public class GetUsuarioMinisterios
{
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IMapper _mapper;

    public GetUsuarioMinisterios(IAmbienteUsuarioService ambienteUsuarioService, IMapper mapper, IUnitOfWork uow)
    {
        _ambienteUsuarioService = ambienteUsuarioService;
        _mapper = mapper;
        _uow = uow;
    }
    
    public async Task<RespostaBase<List<GetUsuarioMinisterioDto>>> ExecuteAsync()
    {
        var usuarioLogado = await _ambienteUsuarioService.GetUsuarioAsync();
        
        var query = _uow.UsuarioMinisterios
            .RecuperarTodos("Ministerio", "Usuario")
            .WhereNotRemovido(GetCondicao(usuarioLogado.Id));
        
        var totalUsuarioMinisterios = await query.CountAsync();
        
        var usuarioMinisterios = await query
            .ToListAsync();
        
        var usuarioMinisteriosDto = _mapper.Map<List<GetUsuarioMinisterioDto>>(usuarioMinisterios);
        
        var respostaBase = new RespostaBase<List<GetUsuarioMinisterioDto>>(
            RespostaBaseMensagem.GetUsuarioMinisterios, usuarioMinisteriosDto, totalUsuarioMinisterios);
        
        return respostaBase;
    }
    
    private static Expression<Func<UsuarioMinisterio, bool>> GetCondicao(int usuarioId)
    {
        return x => x.UsuarioId == usuarioId;
    }
}