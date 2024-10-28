using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class EscalaItem : EntidadeBase
    {
        public int EscalaId { get; set; }
        public int AtividadeId { get; set; }
        public int VoluntarioId { get; set; }

        public EscalaItem()
        {
        }
        
        public EscalaItem(int escalaId, int atividadeId, int voluntarioId)
        {
            EscalaId = escalaId;
            AtividadeId = atividadeId;
            VoluntarioId = voluntarioId;
        }

        public Escala Escala { get; set; }
        public Atividade.Atividade Atividade { get; set; }
        public Voluntario Voluntario { get; set; }
    }
}
