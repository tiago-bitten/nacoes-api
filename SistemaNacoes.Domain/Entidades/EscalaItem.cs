namespace SistemaNacoes.Domain.Entidades
{
    public class EscalaItem
    {
        public int EscalaId { get; set; }
        public int AtividadeId { get; set; }
        public int VoluntarioId { get; set; }
        public int QuantidadeVoluntarios { get; set; }

        public Escala Escala { get; set; }
        public Atividade Atividade { get; set; }
        public Voluntario Voluntario { get; set; }
    }
}
