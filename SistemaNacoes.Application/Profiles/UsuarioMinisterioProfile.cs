using AutoMapper;
using SistemaNacoes.Application.Dtos.UsuarioMinisterios;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class UsuarioMinisterioProfile : Profile
{
    public UsuarioMinisterioProfile()
    {
        CreateMap<UsuarioMinisterio, GetUsuarioMinisterioDto>();
    }
}