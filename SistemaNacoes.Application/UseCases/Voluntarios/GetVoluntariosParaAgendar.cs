using AutoMapper;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Voluntarios;

public class GetVoluntariosParaAgendar
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
}