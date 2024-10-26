﻿using AutoMapper;
using SistemaNacoes.Application.UseCases.Voluntarios.CriarVoluntario.Dtos;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.Profiles;

public class VoluntarioProfile : Profile
{
    public VoluntarioProfile()
    {
        CreateMap<Voluntario, CriarVoluntarioResult>()
            .ForMember(dest => dest.VoluntarioId, opt => opt.MapFrom(src => src.Id));
    }
}