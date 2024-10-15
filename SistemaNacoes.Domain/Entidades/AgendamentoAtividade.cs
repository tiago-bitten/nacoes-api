using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades;

public sealed class AgendamentoAtividade : EntidadeBase
{
    public int AgendamentoId { get; set; }
    public int AtividadeId { get; set; }
    
    public Agendamento Agendamento { get; set; }
    public Atividade Atividade { get; set; }
    
    
    public AgendamentoAtividade()
    {
    }
    
    public AgendamentoAtividade(Agendamento agendamento, Atividade atividade)
    {
        Agendamento = agendamento;
        Atividade = atividade;
    }
    
    public AgendamentoAtividade(int agendamentoId, int atividadeId)
    {
        AgendamentoId = agendamentoId;
        AtividadeId = atividadeId;
    }
    
    public void GaranteExiste() 
    {
        if (Removido)
            throw new NacoesAppException(MensagemErroConstant.AgendamentoAtividadeJaRemovido);
    }
}