﻿using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Domain.Entidades.Usuario
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario?> RecuperarPorEmailAsync(string email);
        Task<Usuario?> RecuperarPorCpfAsync(string cpf);
    }
}