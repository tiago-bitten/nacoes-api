namespace SistemaNacoes.Application.Responses;

public static class MensagemRepostasConstant
{
    //Voluntarios
    public const string CreateVoluntario = "Voluntário cadastrado com sucesso";
    public const string GetVoluntario = "Voluntário encontrado com sucesso";
    public const string GetVoluntarios = "Voluntários listados com sucesso";
    public const string DeleteVoluntario = "Voluntário deletado com sucesso";
    public const string GetVoluntariosParaAgendar = "Voluntários para agendar listados com sucesso";
    
    //Ministerios
    public const string CreateMinisterio = "Ministério cadastrado com sucesso";
    public const string GetMinisterio = "Ministério encontrado com sucesso";
    public const string GetMinisterios = "Ministérios listados com sucesso";
    public const string DeleteMinisterio = "Ministério deletado com sucesso";
    
    //VoluntarioMinisterios
    public const string VinculateVoluntarioMinisterio = "Voluntário vinculado ao ministério com sucesso";
    public const string GetVoluntarioMinisterio = "Voluntário e ministério encontrado com sucesso";
    public const string GetVoluntariosMinisterios = "Voluntários e ministérios listados com sucesso";
    public const string DesvinculateVoluntarioMinisterio = "Voluntário desvinculado do ministério com sucesso";

    //Agendas
    public const string OpenAgenda = "Agenda cadastrada com sucesso";
    public const string CloseAgenda = "Agenda fechada com sucesso";
    public const string GetAgenda = "Agenda encontrada com sucesso";
    public const string GetAgendas = "Agendas listadas com sucesso";
    public const string FinalizeAgenda = "Agenda finalizada com sucesso";
    
    //DataIndisponiveis
    public const string CreateDataIndisponivel = "Data indisponível cadastrada com sucesso";
    public const string SuspendDataIndisponivel = "Data indisponível suspensa com sucesso";
    public const string GetDataIndisponivel = "Data indisponível encontrada com sucesso";
    public const string GetDataIndisponiveis = "Datas indisponíveis listadas com sucesso";
    public const string DeleteDataIndisponivel = "Data indisponível deletada com sucesso";
    
    //Agendamentos
    public const string CreateAgendamento = "Agendamento cadastrado com sucesso";
    public const string GetAgendamento = "Agendamento encontrado com sucesso";
    public const string GetAgendamentos = "Agendamentos listados com sucesso";
    public const string DeleteAgendamento = "Agendamento deletado com sucesso";
    
    //Atividades
    public const string CreateAtividade = "Atividade cadastrada com sucesso";
    public const string GetAtividade = "Atividade encontrada com sucesso";
    public const string GetAtividades = "Atividades listadas com sucesso";
    public const string DeleteAtividade = "Atividade deletada com sucesso";
    
    //AgendamentoAtividades
    public const string VinculateAtividadeAgendamento = "Atividade vinculada ao agendamento com sucesso";
    public const string DeleteAgendamentoAtividade = "AgendamentoAtividade deletada com sucesso";
    
    //Grupos
    public const string CreateGrupo = "Grupo cadastrado com sucesso";
    public const string GetGrupo = "Grupo encontrado com sucesso";
    public const string GetGrupos = "Grupos listados com sucesso";
    public const string DeleteGrupo = "Grupo deletado com sucesso";
    public const string VinculateVoluntarioGrupo = "Voluntário vinculado ao grupo com sucesso";
    
    //GrupoVoluntarios
    public const string GetVoluntariosNoGrupo = "Voluntários no grupo listados com sucesso";
    
    // Auth
    public const string GetAuthToken = "Tokens gerados com sucesso";
    public const string LoginSucesso = "Login realizado com sucesso";
    
    // Usuarios
    public const string CreateUsuario = "Usuário cadastrado com sucesso";
    public const string GetUsuario = "Usuário encontrado com sucesso";
    public const string GetUsuarios = "Usuários listados com sucesso";
    
    // UsuarioMinisterios
    public const string VinculateUsuarioMinisterio = "Usuário vinculado ao ministério com sucesso";
    public const string GetUsuarioMinisterio = "Usuário e ministério encontrado com sucesso";
    public const string GetUsuarioMinisterios = "Usuários e ministérios listados com sucesso";
    
    // Permissoes
    public const string GetPermissoes = "Permissões listadas com sucesso";
    public const string RemoveUsuarioPermissoes = "Permissões do usuário removidas com sucesso";
    public const string GetUsuarioPermissoes = "Permissões do usuário listadas com sucesso";
    public const string AddPermissoesUsuario = "Permissões do usuário adicionadas com sucesso";
}