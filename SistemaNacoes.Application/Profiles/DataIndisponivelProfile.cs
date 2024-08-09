using AutoMapper;
using SistemaNacoes.Application.Dtos.DataIndisponiveis;
using SistemaNacoes.Application.UseCases.DataIndisponiveis;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class DataIndisponivelProfile : Profile
{
    public DataIndisponivelProfile()
    {
        CreateMap<CreateDataIndisponivelDto, DataIndisponivel>()
            .ForMember(dest => dest.Voluntario.ChaveAcesso, opt => opt.MapFrom(src => src.VoluntarioChaveAcesso));
        
        CreateMap<DataIndisponivel, GetDataIndisponivelDto>();
    }
}