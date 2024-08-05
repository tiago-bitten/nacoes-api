namespace SistemaNacoes.Domain.Entidades
{
    public class EscalaItem
    {
        public EscalaItem(Escala escala, Atividade atividade, Voluntario voluntario, int quantidadeVoluntarios)
        {
            Escala = escala;
            Atividade = atividade;
            Voluntario = voluntario;
            QuantidadeVoluntarios = quantidadeVoluntarios;
        }
        
        public int EscalaId { get; set; }
        public int AtividadeId { get; set; }
        public int VoluntarioId { get; set; }
        public int QuantidadeVoluntarios { get; set; }
        public bool Removido { get; set; } = false;

        public Escala Escala { get; set; }
        public Atividade Atividade { get; set; }
        public Voluntario Voluntario { get; set; }
    }
}
