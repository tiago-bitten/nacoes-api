using AutoMapper;
using SistemaNacoes.Application.UseCases.Usuarios.CriarUsuario.Dtos;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Usuario, CriarUsuarioResult>()
            .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.Id));
    }
}