using AutoMapper;
using SistemaNacoes.Application.UseCases.UsuarioMinisterios.CriarUsuarioMinisterio.Dtos;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class UsuarioMinisterioProfile : Profile
{
    public UsuarioMinisterioProfile()
    {
        CreateMap<UsuarioMinisterio, CriarUsuarioMinisterioResult>()
            .ForMember(dest => dest.UsuarioMinisterioId, opt => opt.MapFrom(src => src.Id));
    }
}