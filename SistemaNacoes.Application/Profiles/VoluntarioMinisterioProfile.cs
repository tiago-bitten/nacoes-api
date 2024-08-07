using AutoMapper;
using SistemaNacoes.Application.Dtos.VoluntarioMinisterios;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class VoluntarioMinisterioProfile : Profile
{
    public VoluntarioMinisterioProfile()
    {
        CreateMap<VoluntarioMinisterio, GetSimpVoluntarioMinisterioDto>();
    }
}