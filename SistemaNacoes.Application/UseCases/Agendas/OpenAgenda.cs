using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendas;
using SistemaNacoes.Application.Extensions;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendas;

public class OpenAgenda
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IRegistroCriacaoService _registroCriacaoService;

    public OpenAgenda(IUnitOfWork uow, IMapper mapper, IAmbienteUsuarioService ambienteUsuarioService, IRegistroCriacaoService registroCriacaoService)
    {
        _uow = uow;
        _mapper = mapper;
        _ambienteUsuarioService = ambienteUsuarioService;
        _registroCriacaoService = registroCriacaoService;
    }

    public async Task<RespostaBase<GetAgendaDto>> ExecuteAsync(OpenAgendaDto dto)
    {
        var usuarioLogado = await _ambienteUsuarioService.GetUsuarioAsync();

        if (!usuarioLogado.HasPermission(EPermissoes.OPEN_AGENDA))
            throw new Exception(MensagemErroConstant.SemPermissaoParaAbrirAgenda);
        
        if (dto.DataFinal < dto.DataInicio)
            throw new Exception("Data final não pode ser menor que a data inicial");

        var agenda = _mapper.Map<Agenda>(dto);

        await _uow.Agendas.AddAsync(agenda);
        await _uow.CommitAsync();

        await _registroCriacaoService.LogAsync("agendas", agenda.Id);

        var agendaDto = _mapper.Map<GetAgendaDto>(agenda);

        var responstaBase = new RespostaBase<GetAgendaDto>(RespostaBaseMensagem.OpenAgenda, agendaDto);
        
        return responstaBase;
    }
}