﻿using SistemaNacoes.Application.Dtos.Permissoes;
using SistemaNacoes.Application.Extensions;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Permissoes;

public class RemovePermissoesUsuario
{
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly IServiceBase<Usuario> _usuarioService;

    public RemovePermissoesUsuario(IUnitOfWork uow, IAmbienteUsuarioService ambienteUsuarioService, IServiceBase<Usuario> usuarioService)
    {
        _uow = uow;
        _ambienteUsuarioService = ambienteUsuarioService;
        _usuarioService = usuarioService;
    }

    public async Task<RespostaBase<dynamic>> ExecuteAsync(RemoveUsuarioPermissoesDto dto)
    {
        var usuarioLogado = await _ambienteUsuarioService.GetUsuarioAsync();

        if (!usuarioLogado.HasPermission(EPermissoes.UPDATE_USUARIO))
            throw new Exception(MensagemErroConstant.SemPermissaoParaAlterarUsuario);

        var usuario = await _usuarioService.GetAndEnsureExistsAsync(dto.UsuarioId);

        var originalPermissions = usuario.Permissoes;

        foreach (var permissao in dto.Permissoes)
        {
            usuario.Permissoes &= ~permissao;
        }

        if (originalPermissions != usuario.Permissoes)
        {
            _uow.Usuarios.Update(usuario);
            await _uow.CommitAsync();
        }
        
        return new RespostaBase<dynamic>(
            RespostaBaseMensagem.RemoveUsuarioPermissoes);
    }
}