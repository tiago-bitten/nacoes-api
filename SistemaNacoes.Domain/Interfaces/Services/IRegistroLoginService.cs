﻿using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Interfaces.Services;

public interface IRegistroLoginService
{
    Task LoginAttemptAsync(HistoricoLogin registroLogin);    
    Task LogSuccessLoginAsync(int usuarioId);
    Task LogFailedLoginAsync(int? usuarioId, EMotivoLoginAcessoNegado motivo);
}