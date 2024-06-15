using AutoMapper;
using SistemaNacoes.Application.DTOs;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.WebAPI.Mapeamentos
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, LerUsuarioDTO>();
            CreateMap<CriarUsuarioDTO, Usuario>();
        }
    }
}
