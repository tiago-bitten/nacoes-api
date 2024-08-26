using AutoMapper;
using SistemaNacoes.Application.Dtos.Usuarios;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<Usuario, GetUsuarioDto>();
        CreateMap<Usuario, GetSimpUsuarioDto>();
    }
}