using AutoMapper;
using SistemaNacoes.Application.Dtos.Grupos;
using SistemaNacoes.Application.UseCases.Grupos;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class GrupoProfile : Profile
{
    public GrupoProfile()
    {
        CreateMap<CreateGrupoDto, Grupo>();
        
        CreateMap<Grupo, GetGrupoDto>()
            .ForMember(dest => dest.MinisterioPrefencial, opt => opt.MapFrom(src => src.MinisterioPreferencial));
    }
}