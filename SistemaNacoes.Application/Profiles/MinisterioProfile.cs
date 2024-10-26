﻿using AutoMapper;
using SistemaNacoes.Application.UseCases.Ministerios.CriarMinisterio.Dtos;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class MinisterioProfile : Profile
{
    public MinisterioProfile()
    {
        CreateMap<Ministerio, CriarMinisterioResult>()
            .ForMember(dest => dest.MinisterioId, opt => opt.MapFrom(src => src.Id));
    }
}