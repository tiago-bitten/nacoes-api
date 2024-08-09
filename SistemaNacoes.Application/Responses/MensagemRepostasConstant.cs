namespace SistemaNacoes.Application.Responses;

public static class MensagemRepostasConstant
{
    //Voluntarios
    public const string CreateVoluntario = "Voluntário cadastrado com sucesso";
    public const string GetVoluntario = "Voluntário encontrado com sucesso";
    public const string GetVoluntarios = "Voluntários listados com sucesso";
    
    //Ministerios
    public const string CreateMinisterio = "Ministério cadastrado com sucesso";
    public const string GetMinisterio = "Ministério encontrado com sucesso";
    public const string GetMinisterios = "Ministérios listados com sucesso";
    
    //VoluntarioMinisterios
    public const string VinculateVoluntarioMinisterio = "Voluntário vinculado ao ministério com sucesso";
    public const string GetVoluntarioMinisterio = "Voluntário e ministério encontrado com sucesso";
    public const string GetVoluntariosMinisterios = "Voluntários e ministérios listados com sucesso";

    //Agendas
    public const string OpenAgenda = "Agenda cadastrada com sucesso";
    public const string CloseAgenda = "Agenda fechada com sucesso";
    public const string GetAgenda = "Agenda encontrada com sucesso";
    public const string GetAgendas = "Agendas listadas com sucesso";
    public const string FinalizeAgenda = "Agenda finalizada com sucesso";
    
    //DataIndisponiveis
    public const string CreateDataIndisponivel = "Data indisponível cadastrada com sucesso";
    
    //Agendamentos
    public const string CreateAgendamento = "Agendamento cadastrado com sucesso";
}