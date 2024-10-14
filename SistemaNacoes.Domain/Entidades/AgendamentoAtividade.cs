using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades;

public sealed class AgendamentoAtividade : EntidadeBase
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
    
    public Agendamento Agendamento { get; set; }
    public Atividade Atividade { get; set; }
    
    public void GaranteExiste() 
    {
        if (Removido)
            throw new NacoesAppException(MensagemErroConstant.AgendamentoAtividadeJaRemovido);
    }
}