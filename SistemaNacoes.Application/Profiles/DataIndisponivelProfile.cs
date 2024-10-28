using AutoMapper;
using SistemaNacoes.Application.UseCases.DataIndisponiveis.CriarDataIndisponivel.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.DataIndisponivel;

namespace SistemaNacoes.Application.Profiles;

public class DataIndisponivelProfile : Profile
{
    public DataIndisponivelProfile()
    {
        CreateMap<DataIndisponivel, CriarDataIndisponivelResult>()
            .ForMember(dest => dest.DataIndisponivelId, opt => opt.MapFrom(src => src.Id));
    }
}