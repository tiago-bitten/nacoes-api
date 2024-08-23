using AutoMapper;
using SistemaNacoes.Application.Dtos.Auth;

namespace SistemaNacoes.Application.Profiles;

public class AuthTokenProfile : Profile
{
    public AuthTokenProfile()
    {
        CreateMap<(string AccessToken, string RefreshToken, DateTime ExpiresIn), GetAuthTokenDto>()
            .ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.AccessToken))
            .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.RefreshToken))
            .ForMember(dest => dest.ExpiresIn, opt => opt.MapFrom(src => src.ExpiresIn));
    }
}