using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class AgendamentoProfile : Profile
{
    public AgendamentoProfile()
    {
        CreateMap<CreateAgendamentoDto, Agendamento>();

        CreateMap<Agendamento, GetAgendamentoDto>()
            .ForMember(dest => dest.Atividades, opt => opt.MapFrom(src => src.AgendamentoAtividades.Select(x => x.Atividade)));
    }
}