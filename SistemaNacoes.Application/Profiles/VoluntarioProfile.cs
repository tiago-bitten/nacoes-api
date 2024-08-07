using AutoMapper;
using SistemaNacoes.Application.Dtos.VoluntarioMinisterios;
using SistemaNacoes.Application.Dtos.Voluntarios;
using SistemaNacoes.Application.UseCases.Voluntarios;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class VoluntarioProfile : Profile
{
    public VoluntarioProfile()
    {
        CreateMap<CreateVoluntarioDto, Voluntario>();
        
        CreateMap<Voluntario, GetVoluntarioDto>();

        CreateMap<Voluntario, GetSimpVoluntarioDto>();
        
        CreateMap<Voluntario, GetSimpVoluntarioMinisterioDto>();
    }
}