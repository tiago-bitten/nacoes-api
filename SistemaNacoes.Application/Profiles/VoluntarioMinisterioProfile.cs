using AutoMapper;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.CriarVoluntarioMinisterio.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.VoluntarioMinisterio;

namespace SistemaNacoes.Application.Profiles;

public class VoluntarioMinisterioProfile : Profile
{
    public VoluntarioMinisterioProfile()
    {
        CreateMap<VoluntarioMinisterio, CriarVoluntarioMinisterioResult>()
            .ForMember(dest => dest.VoluntarioMinisteriosId, opt => opt.MapFrom(src => src.Id));
    }
}