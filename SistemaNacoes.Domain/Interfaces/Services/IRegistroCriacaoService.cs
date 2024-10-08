﻿using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IRegistroCriacaoService
{
    Task LogAsync(string tabela, int itemId);
    Task LogRangeAsync(string tabela, IEnumerable<int> itemIds);
}