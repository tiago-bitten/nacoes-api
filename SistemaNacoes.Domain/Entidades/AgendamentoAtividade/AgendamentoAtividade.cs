using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.AgendamentoAtividade;

public sealed class AgendamentoAtividade : EntidadeBase
{
    public int AgendamentoId { get; set; }
    public int AtividadeId { get; set; }
    
    public Agendamento.Agendamento Agendamento { get; set; }
    public Atividade.Atividade Atividade { get; set; }
    
    
    public AgendamentoAtividade()
    {
    }
    
    public AgendamentoAtividade(Agendamento.Agendamento agendamento, Atividade.Atividade atividade)
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