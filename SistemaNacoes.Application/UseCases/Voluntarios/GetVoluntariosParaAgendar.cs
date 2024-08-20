using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Dtos.Outros;
using SistemaNacoes.Application.Dtos.Voluntarios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Voluntarios;

public class GetVoluntariosParaAgendar
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IAgendaService _agendaService;
    private readonly IMinisterioService _ministerioService;
    private readonly IDataIndisponivelService _dataIndisponivelService;

    public GetVoluntariosParaAgendar(IUnitOfWork uow, IMapper mapper, IAgendaService agendaService, IMinisterioService ministerioService, IDataIndisponivelService dataIndisponivelService)
    {
        _uow = uow;
        _mapper = mapper;
        _agendaService = agendaService;
        _ministerioService = ministerioService;
        _dataIndisponivelService = dataIndisponivelService;
    }

    public async Task<RespostaBase<List<GetVoluntarioParaAgendarDto>>> ExecuteAsync(int agendaId, int ministerioId)
    {
        var agenda = await _agendaService.GetAndEnsureExistsAsync(agendaId);
        await _ministerioService.GetAndEnsureExistsAsync(ministerioId);

        var includes = new[]
        {
            nameof(Voluntario.VoluntarioMinisterios),
            nameof(Voluntario.Agendamentos),
            $"{nameof(Voluntario.Agendamentos)}.{nameof(Agendamento.Agenda)}"
        };
        
        var voluntarios = await _uow.Voluntarios
            .GetAll(includes)
            .Where(x => !x.Removido 
                        && x.VoluntarioMinisterios.Any(vm => vm.MinisterioId == ministerioId && vm.Ativo) 
                        && x.Agendamentos.All(a => a.AgendaId != agendaId || a.Removido))
            .ToListAsync();

        var totalVoluntarios = voluntarios.Count;
        
        var getVoluntariosParaAgendarDtos = new List<GetVoluntarioParaAgendarDto>();
        
        foreach (var voluntario in voluntarios)
        {
            var getVoluntarioParaAgendarDto = new GetVoluntarioParaAgendarDto();
            var motivoIndisponibilidades = new List<GetMotivoIndisponibilidadeDto>();
            
            getVoluntarioParaAgendarDto.Voluntario = _mapper.Map<GetSimpVoluntarioDto>(voluntario);
            getVoluntarioParaAgendarDto.Disponivel = true;
            getVoluntarioParaAgendarDto.MotivoIndisponibilidades = motivoIndisponibilidades;
            
            var disponivelPorData = _dataIndisponivelService.EnsureDateIsAvailable(agenda, voluntario);

            if (!disponivelPorData)
            {
                getVoluntarioParaAgendarDto.Disponivel = false;
                motivoIndisponibilidades.Add(new GetMotivoIndisponibilidadeDto
                {
                    Motivo = "Voluntário indisponível na data selecionada"
                });
            }
            
            getVoluntariosParaAgendarDtos.Add(getVoluntarioParaAgendarDto);
        }
        
        var respostaBase = new RespostaBase<List<GetVoluntarioParaAgendarDto>>(MensagemRepostasConstant.GetVoluntariosParaAgendar, getVoluntariosParaAgendarDtos, totalVoluntarios);
        
        return respostaBase;
    }
}