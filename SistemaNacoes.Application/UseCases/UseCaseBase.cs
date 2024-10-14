using AutoMapper;
using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases;

public class UseCaseBase<TEntidade, TService> where TEntidade : EntidadeBase
{
    protected readonly IUnitOfWork Uow;
    protected readonly IMapper Mapper;
    private readonly IServiceBase<TEntidade> _service;

    protected UseCaseBase(IUnitOfWork uow, IMapper mapper)
    {
        Uow = uow;
        _mapper = mapper;
    }

    protected TService Service => (TService)_service;
}