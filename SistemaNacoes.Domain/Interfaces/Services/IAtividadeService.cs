﻿using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IAtividadeService : IServiceBase<Atividade>
{
    Task EnsureExistsAtividadeNoMinisterioAsync(int id, int ministerioId);
    Task<bool> ExisteAtividadeNoMinisterioAsync(int id, int ministerioId);
}