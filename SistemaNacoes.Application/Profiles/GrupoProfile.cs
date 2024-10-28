using AutoMapper;
using SistemaNacoes.Application.UseCases.Grupos.CriarGrupo.Dtos;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Entidades.Grupo;

namespace SistemaNacoes.Application.Profiles;

public class GrupoProfile : Profile
{
    public GrupoProfile()
    {
        CreateMap<Grupo, CriarGrupoResult>()
            .ForMember(dest => dest.GrupoId, opt => opt.MapFrom(src => src.Id));
    }
}