namespace SistemaNacoes.Domain.Entidades;

public sealed class AgendamentoAtividade
{
    public AgendamentoAtividade()
    {
    }
    
    public AgendamentoAtividade(Agendamento agendamento, Atividade atividade)
    {
        Agendamento = agendamento;
        Atividade = atividade;
    }
    
    public int AgendamentoId { get; set; }
    public int AtividadeId { get; set; }
    public bool Removido { get; set; } = false;
    
    public Agendamento Agendamento { get; set; }
    public Atividade Atividade { get; set; }
}