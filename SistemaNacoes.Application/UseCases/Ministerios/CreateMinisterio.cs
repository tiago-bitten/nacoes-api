using AutoMapper;
using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Ministerios;

public class CreateMinisterio
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateMinisterio(
        IUnitOfWork uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<RespostaBase<GetMinisterioDto>> ExecuteAsync(CreateMinisterioDto dto)
    {
        var ministerio = _mapper.Map<Ministerio>(dto);
        
        await _uow.Ministerios.AddAsync(ministerio);
        await _uow.CommitAsync();
        
        var ministerioDto = _mapper.Map<GetMinisterioDto>(ministerio);

        var respostaBase = new RespostaBase<GetMinisterioDto>
        {
            Sucesso = true,
            Mensagem = "Ministério cadastrado com sucesso",
            Conteudo = ministerioDto
        };

        return respostaBase;
    }
}