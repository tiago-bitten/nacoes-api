using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Usuarios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Usuarios;

public class GetAllUsuarios
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllUsuarios(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RespostaBase<List<GetSimpUsuarioDto>>> ExecuteAsync(QueryParametro queryParametro)
    {
        var query = _uow.Usuarios
            .GetAll()
            .Where(GetCondicao());
    
        var totalUsuarios = await query.CountAsync();
        
        var usuarios = await query
            .Skip(queryParametro.Skip)
            .Take(queryParametro.Take)
            .ToListAsync();

        var usuariosDto = _mapper.Map<List<GetSimpUsuarioDto>>(usuarios);
    
        var respostaBase = new RespostaBase<List<GetSimpUsuarioDto>>(
            RespostaBaseMensagem.GetUsuarios, usuariosDto, totalUsuarios);

        return respostaBase;
    }

    private static Expression<Func<Usuario, bool>> GetCondicao()
    {
        return x => !x.Removido;
    }
}