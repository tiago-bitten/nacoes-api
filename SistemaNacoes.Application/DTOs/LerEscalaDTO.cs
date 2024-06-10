namespace SistemaNacoes.Application.DTOs
{
    public class LerEscalaDTO
    {
        public int Id { get; set; }
        public int QuantidadeVoluntarios { get; set; }
        public LerAgendaDTO Agenda { get; set; }
        public LerMinisterioDTO Ministerio { get; set; }
    }
}
