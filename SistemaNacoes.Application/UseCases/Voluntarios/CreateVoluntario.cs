using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SistemaNacoes.Application.Dtos.Voluntarios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Voluntarios;

public class CreateVoluntario
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateVoluntario(
        IUnitOfWork uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RespostaBase<GetVoluntarioDto>> ExecuteAsync(CreateVoluntarioDto dto)
    {
        if (!string.IsNullOrEmpty(dto.Cpf))
        {
            var existsByCpf = await _uow.Voluntarios.FindAsync(x => x.Cpf == dto.Cpf);
            if (existsByCpf != null)
                throw new Exception("CPF já cadastrado");
        }

        var voluntario = _mapper.Map<Voluntario>(dto);
        
        await _uow.Voluntarios.AddAsync(voluntario);
        await _uow.CommitAsync();
        
        var voluntarioDto = _mapper.Map<GetVoluntarioDto>(voluntario);

        var respostaBase = new RespostaBase<GetVoluntarioDto>(
            MensagemRepostasConstant.CreateVoluntario, voluntarioDto);

        return respostaBase;
    }
}