using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SistemaNacoes.Application.Dtos.Voluntarios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Voluntarios;

public class CreateVoluntario
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IRegistroCriacaoService _registroCriacaoService;

    public CreateVoluntario(
        IUnitOfWork uow,
        IMapper mapper, IAmbienteUsuarioService ambienteUsuarioService, IRegistroCriacaoService registroCriacaoService)
    {
        _uow = uow;
        _mapper = mapper;
        _ambienteUsuarioService = ambienteUsuarioService;
        _registroCriacaoService = registroCriacaoService;
    }

    public async Task<RespostaBase<GetVoluntarioDto>> ExecuteAsync(CreateVoluntarioDto dto)
    {
        var usuarioLogado = await _ambienteUsuarioService.GetUsuarioAsync();
        
        if (!usuarioLogado.HasPermission(EPermissoes.CREATE_VOLUNTARIO))
            throw new Exception(MensagemErroConstant.SemPermissaoParaCriarVoluntario);
        
        if (!string.IsNullOrEmpty(dto.Cpf))
        {
            var existsByCpf = await _uow.Voluntarios.BuscarAsync(x => x.Cpf == dto.Cpf);
            if (existsByCpf != null)
                throw new Exception("CPF já cadastrado");
        }

        var voluntario = _mapper.Map<Voluntario>(dto);
        
        await _uow.Voluntarios.AdicionarAsync(voluntario);
        await _uow.CommitAsync();
        
        await _registroCriacaoService.LogAsync("voluntarios", voluntario.Id);
        
        var voluntarioDto = _mapper.Map<GetVoluntarioDto>(voluntario);

        var respostaBase = new RespostaBase<GetVoluntarioDto>(
            RespostaBaseMensagem.CreateVoluntario, voluntarioDto);

        return respostaBase;
    }
}