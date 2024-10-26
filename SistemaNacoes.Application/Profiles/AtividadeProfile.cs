﻿using AutoMapper;
using SistemaNacoes.Application.UseCases.Atividades.CriarAtividade.Dtos;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class AtividadeProfile : Profile
{
    public AtividadeProfile()
    {
        CreateMap<Atividade, CriarAtividadeResult>()
            .ForMember(dest => dest.AtividadeId, opt => opt.MapFrom(src => src.Id));
    }
}