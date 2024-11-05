using System.ComponentModel;

namespace SistemaNacoes.Domain.Enums;

[Flags]
public enum EPermissoes : long
{
    Nenhuma = 0L,
    
    // Agenda
    [Description("Abrir agenda")]
    AbrirAgenda = 1L << 0, // 1(2^0)
    
    [Description("Alterar status da agenda")]
    AlterarStatusAgenda = 1L << 1, // 2(2^1)
    
    [Description("Visualizar agenda")]
    VisualizarAgenda = 1L << 2, // 4(2^2)
    
    [Description("Atualizar agenda")]
    AtualizarAgenda = 1L << 3, // 8(2^3)
    
    // Agendamento
    [Description("Criar agendamento")]
    CriarAgendamento = 1L << 4, // 16(2^4)
    
    [Description("Remover agendamento")]
    RemoverAgendamento = 1L << 5, // 32(2^5)
    
    [Description("Remover agendamento de atividade")]
    RemoverAgendamentoAtividade = 1L << 6, // 64(2^6)
    
    [Description("Visualizar agendamento")]
    VisualizarAgendamento = 1L << 7, // 128(2^7)
    
    [Description("Vincular agendamento a atividade")]
    VincularAgendamentoAtividade = 1L << 8, // 256(2^8)
    
    // Atividade
    [Description("Criar atividade")]
    CriarAtividade = 1L << 9, // 512(2^9)
    
    [Description("Remover atividade")]
    RemoverAtividade = 1L << 10, // 1024(2^10)
    
    [Description("Visualizar atividade")]
    VisualizarAtividade = 1L << 11, // 2048(2^11)
    
    [Description("Atualizar atividade")]
    AtualizarAtividade = 1L << 12, // 4096(2^12)
    
    // Voluntário
    [Description("Criar voluntário")]
    CriarVoluntario = 1L << 13, // 8192(2^13)
    
    [Description("Remover voluntário")]
    RemoverVoluntario = 1L << 14, // 16384(2^14)
    
    [Description("Visualizar voluntário")]
    VisualizarVoluntario = 1L << 15, // 32768(2^15)
    
    [Description("Atualizar voluntário")]
    AtualizarVoluntario = 1L << 16, // 65536(2^16)
    
    // Ministério
    [Description("Criar ministério")]
    CriarMinisterio = 1L << 17, // 131072(2^17)
    
    [Description("Remover ministério")]
    RemoverMinisterio = 1L << 18, // 262144(2^18)
    
    [Description("Visualizar ministério")]
    VisualizarMinisterio = 1L << 19, // 524288(2^19)
    
    [Description("Atualizar ministério")]
    AtualizarMinisterio = 1L << 20, // 1048576(2^20)
    
    // VoluntárioMinistério
    [Description("Criar voluntário no ministério")]
    CriarVoluntarioMinisterio = 1L << 21, // 2097152(2^21)
    
    [Description("Remover voluntário no ministério")]
    RemoverVoluntarioMinisterio = 1L << 22, // 4194304(2^22)
    
    [Description("Visualizar voluntário no ministério")]
    VisualizarVoluntarioMinisterio = 1L << 23, // 8388608(2^23)
    
    // Usuário
    [Description("Criar usuário")]
    CriarUsuario = 1L << 24, // 16777216(2^24)
    
    [Description("Remover usuário")]
    RemoverUsuario = 1L << 25, // 33554432(2^25)
    
    [Description("Visualizar usuário")]
    VisualizarUsuario = 1L << 26, // 67108864(2^26)
    
    [Description("Atualizar usuário")]
    AtualizarUsuario = 1L << 27, // 134217728(2^27)
    
    // UsuárioMinistério
    [Description("Criar usuário no ministério")]
    CriarUsuarioMinisterio = 1L << 28, // 268435456(2^28)
    
    [Description("Remover usuário no ministério")]
    RemoverUsuarioMinisterio = 1L << 29, // 536870912(2^29)
    
    [Description("Visualizar usuário no ministério")]
    VisualizarUsuarioMinisterio = 1L << 30, // 1073741824(2^30)
    
    // Grupo
    [Description("Criar grupo")]
    CriarGrupo = 1L << 31, // 2147483648(2^31)
    
    [Description("Remover grupo")]
    RemoverGrupo = 1L << 32, // 4294967296(2^32)
    
    [Description("Visualizar grupo")]
    VisualizarGrupo = 1L << 33, // 8589934592(2^33)
    
    [Description("Atualizar grupo")]
    AtualizarGrupo = 1L << 34, // 17179869184(2^34)
    
    // GrupoVoluntario
    [Description("Criar voluntário no grupo")]
    CriarVoluntarioGrupo = 1L << 35, // 34359738368(2^35)
    
    [Description("Remover voluntário no grupo")]
    RemoverVoluntarioGrupo = 1L << 36, // 68719476736(2^36)
    
    [Description("Visualizar voluntário no grupo")]
    VisualizarVoluntarioGrupo = 1L << 37, // 137438953472(2^37)
    
    // DataIndisponível
    [Description("Criar data indisponível")]
    CriarDataIndisponivel = 1L << 38, // 274877906944(2^38)
    
    [Description("Remover data indisponível")]
    RemoverDataIndisponivel = 1L << 39, // 549755813888(2^39)
    
    [Description("Visualizar data indisponível")]
    VisualizarDataIndisponivel = 1L << 40, // 1099511627776(2^40)
    
    [Description("Suspender data indisponível")]
    SuspenderDataIndisponivel = 1L << 41, // 2199023255552(2^41)
    
    [Description("Atualizar data indisponível")]
    AtualizarDataIndisponivel = 1L << 42, // 4398046511104(2^42)
    
    // Escala
    [Description("Criar escala")]
    CriarEscala = 1L << 43, // 8796093022208(2^43)
    
    // Perfil de Acesso
    [Description("Criar perfil de acesso")]
    CriarPerfilAcesso = 1L << 44, // 17592186044416(2^44)
    
    [Description("Remover perfil de acesso")]
    RemoverPerfilAcesso = 1L << 45, // 35184372088832(2^45)
    
    [Description("Visualizar perfil de acesso")]
    VisualizarPerfilAcesso = 1L << 46, // 70368744177664(2^46)
    
    [Description("Atualizar perfil de acesso")]
    AtualizarPerfilAcesso = 1L << 47 // 140737488355328(2^47)
}
