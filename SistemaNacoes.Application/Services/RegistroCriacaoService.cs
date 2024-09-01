using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.Services;

public class RegistroCriacaoService : IRegistroCriacaoService
{
    private readonly IUnitOfWork _uow;

    public RegistroCriacaoService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task LogAsync(RegistroCriacao registroCriacao)
    {
        //var registroCriacao = new RegistroCriacao(tabela, itemId, usuarioId, ip, userAgent);

        await _uow.RegistroCriacoes.AddAsync(registroCriacao);
        
    }
}