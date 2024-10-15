using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendamentos;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento.Dtos;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class AgendamentoProfile : Profile
{
    public AgendamentoProfile()
    {
        CreateMap<CriarAgendamentoRequest, Agendamento>();

        CreateMap<Agendamento, CriarAgendamentoResult>()
            .ForMember(dest => dest.Atividades, opt => opt.MapFrom(src => src.AgendamentoAtividades.Select(x => x.Atividade)));
    }
}