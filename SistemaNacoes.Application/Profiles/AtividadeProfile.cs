using AutoMapper;
using SistemaNacoes.Application.Dtos.Atividades;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class AtividadeProfile : Profile
{
    public AtividadeProfile()
    {
        CreateMap<CreateAtividadeDto, Atividade>();
        
        CreateMap<Atividade, GetSimpAtividadeDto>();
        
        CreateMap<Atividade, GetAtividadeDto>();
    }
}