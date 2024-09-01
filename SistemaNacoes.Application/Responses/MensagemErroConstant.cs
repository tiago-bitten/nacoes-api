﻿namespace SistemaNacoes.Application.Responses;

public static class MensagemErroConstant
{
    public const string NaoEncontrado = "Não encontrado";
    
    // Atividades
    public const string AtividadeNaoPertenceAoMinisterio = "Atividade não pertencente ao ministério";
    public const string AtividadeJaRemovida = "Atividade já removida";
    
    // Agendamentos
    public const string AgendamentoJaExiste = "Voluntário já está agendado";
    public const string AgendamentoJaRemovido = "Agendamento já removido";
    public const string AtividadeJaVinculadaAoAgendamento = "Atividade já vinculada ao agendamento";
    
    // AgendamentoAtividades
    public const string AgendamentoAtividadeNaoEncontrado = "AgendamentoAtividade não encontrado";
    public const string AgendamentoAtividadeJaRemovido = "AgendamentoAtividade já removida";
    
    // VoluntariosMinisterios
    public const string VoluntarioMinisterioNaoEncontrado = "Voluntário vinculado ao ministério não encontrado";
    
    // DataIndisponiveis
    public const string DataIndisponivel = "Voluntário não disponível na data";
    public const string DataIndisponivelJaRemovido = "Data indisponível já removida";
    
    // Ministerios
    public const string MinisterioJaRemovido = "Ministério já removido";
    public const string MinisterioJaExiste = "Ministério já existe";
    
    // Agendas
    public const string AgendaJaFechada = "Agenda já fechada";
    public const string AgendaJaFinalizada = "Agenda já finalizada";
    public const string AgendaNaoDisponivel = "Agenda não disponível";
    
    // Grupos
    public const string GrupoJaRemovido = "Grupo já removido";
    public const string GrupoJaExiste = "Grupo já existe";
    
    // Grupo Voluntarios
    public const string VoluntarioJaPossuiGrupo = "Voluntário já possui grupo";
    
    // Auth
    public const string RefreshTokenNaoEncontrado = "Faça login novamente";
    public const string RefreshTokenExpirado = "Faça login novamente";
    public const string LoginInvalido = "E-mail/Senha inválidos";
    
    // Usuarios
    public const string UsuarioJaCadastrado = "Usuário já cadastrado";
    
    public const string UsuarioMinisterioJaCadastrado = "Usuário já cadastrado no ministério";
    
    // Permissoes
    public const string SemPermissaoRemoverAtividade = "Usuário não tem permissão para remover atividade";
    public const string SemPermissaoParaAlterarUsuario = "Usuário não tem permissão para alterar usuário";
    public const string SemPermissaoParaCriarAgendamento = "Usuário não tem permissão para criar agendamento";
}