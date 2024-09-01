using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IRegistroCriacaoService
{
    Task LogAsync(RegistroCriacao registroCriacao);
}