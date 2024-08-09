using AutoMapper;
using SistemaNacoes.Application.Dtos.DataIndisponiveis;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.DataIndisponiveis;

public class CreateDataIndisponivel
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IVoluntarioService _voluntarioService;

    public CreateDataIndisponivel(IUnitOfWork uow, IMapper mapper, IVoluntarioService voluntarioService)
    {
        _uow = uow;
        _mapper = mapper;
        _voluntarioService = voluntarioService;
    }
    
    public async Task<RespostaBase<GetDataIndisponivelDto>> ExecuteAsync(CreateDataIndisponivelDto dto)
    {
        var voluntario = await _voluntarioService.GetByChaveAcessoAsync(dto.VoluntarioChaveAcesso);
        
        if (dto.DataFinal < dto.DataInicio)
            throw new Exception("Data final não pode ser menor que a data inicial");
        
        var dataIndisponivel = _mapper.Map<DataIndisponivel>(dto);
        
        dataIndisponivel.Voluntario = voluntario;

        await _uow.DataIndisponiveis.AddAsync(dataIndisponivel);
        await _uow.CommitAsync();

        return new RespostaBase<GetDataIndisponivelDto>(MensagemRepostasConstant.CreateDataIndisponivel);
    }
}