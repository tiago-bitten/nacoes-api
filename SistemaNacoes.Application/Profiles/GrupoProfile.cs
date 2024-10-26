using AutoMapper;
using SistemaNacoes.Application.UseCases.Grupos.CriarGrupo.Dtos;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class GrupoProfile : Profile
{
    public GrupoProfile()
    {
        CreateMap<Grupo, CriarGrupoResult>()
            .ForMember(dest => dest.GrupoId, opt => opt.MapFrom(src => src.Id));
    }
}