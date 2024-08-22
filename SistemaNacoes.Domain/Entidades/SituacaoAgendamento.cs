using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades;

public sealed class SituacaoAgendamento : EntidadeBase
{
    public SituacaoAgendamento()
    {
    }
    
    public SituacaoAgendamento(Agendamento agendamento)
    {
        Agendamento = agendamento;
    }
    
    public bool Ativo { get; set; } = true;
    public string? Descricao { get; set; }
    public int AgendamentoId { get; set; }
    
    public Agendamento Agendamento { get; set; }
}