namespace SistemaNacoes.Domain.Entidades
{
    public class DataIndisponivel
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public int? VoluntarioId { get; set; }

        public Voluntario Voluntario { get; set; }
    }
}
