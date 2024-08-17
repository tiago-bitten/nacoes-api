using AutoMapper;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Grupos;

public class VinculateVoluntarioGrupo
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IVoluntarioService _voluntarioService;
    

    public VinculateVoluntarioGrupo(IUnitOfWork uow, IMapper mapper, IVoluntarioService voluntarioService)
    {
        _uow = uow;
        _mapper = mapper;
        _voluntarioService = voluntarioService;
    }

    public async Task<RespostaBase<dynamic>> ExecuteAsync(VinculateVoluntarioGrupoDto dto)
    {
        
    }
}