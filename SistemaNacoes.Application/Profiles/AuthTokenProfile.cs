using AutoMapper;
using SistemaNacoes.Application.UseCases.Auth.Entrar.Dtos;

namespace SistemaNacoes.Application.Profiles;

public class AuthTokenProfile : Profile
{
    public AuthTokenProfile()
    {
        CreateMap<(string AccessToken, string RefreshToken, DateTime ExpiresIn), EntrarResult>()
            .ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.AccessToken))
            .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.RefreshToken));
    }
}