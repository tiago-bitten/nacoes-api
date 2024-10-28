using AutoMapper;
using SistemaNacoes.Application.UseCases.Agendas.AbrirAgenda.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Agenda;

namespace SistemaNacoes.Application.Profiles;

public class AgendaProfile : Profile
{
    public AgendaProfile()
    {
        CreateMap<Agenda, AbrirAgendaResult>()
            .ForMember(dest => dest.AgendaId, opt => opt.MapFrom(src => src.Id));
    }
}