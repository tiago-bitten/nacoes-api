using AutoMapper;
using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Dtos.VoluntarioMinisterios;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class MinisterioProfile : Profile
{
    public MinisterioProfile()
    {
        CreateMap<CreateMinisterioDto, Ministerio>();

        CreateMap<Ministerio, GetMinisterioDto>();
        
        CreateMap<Ministerio, GetSimpVoluntarioMinisterioDto>();
    }
}