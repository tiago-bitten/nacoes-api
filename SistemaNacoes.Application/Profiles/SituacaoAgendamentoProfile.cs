using AutoMapper;
using SistemaNacoes.Application.Dtos.SituacaoAgendamentos;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class SituacaoAgendamentoProfile : Profile
{
    public SituacaoAgendamentoProfile()
    {
        CreateMap<SituacaoAgendamento, GetSituacaoAgendamentoDto>();
    }
}