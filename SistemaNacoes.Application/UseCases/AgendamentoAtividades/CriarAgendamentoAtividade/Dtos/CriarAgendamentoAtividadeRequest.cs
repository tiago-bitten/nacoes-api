using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.AgendamentoAtividades.CriarAgendamentoAtividade.Dtos;

public class CriarAgendamentoAtividadeRequest : Request
{
    public int AgendamentoId { get; set; }
    public List<int> AtividadeIds { get; set; }
}