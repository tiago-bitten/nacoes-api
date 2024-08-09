using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendas;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class AgendaProfile : Profile
{
    public AgendaProfile()
    {
        CreateMap<OpenAgendaDto, Agenda>();
        CreateMap<Agenda, GetAgendaDto>();
    }
}