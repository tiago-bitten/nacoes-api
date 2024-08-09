namespace SistemaNacoes.Domain.Entidades
{
    public class DataIndisponivel : EntidadeBase
    {
        public DataIndisponivel() {}
        public DataIndisponivel(Voluntario voluntario, DateTime dataInicio, DateTime dataFinal)
        {
            Voluntario = voluntario;
            DataInicio = dataInicio;
            DataFinal = dataFinal;
        }
        
        public DataIndisponivel(Voluntario voluntario, DateTime dataInicio, DateTime dataFinal, string motivo)
        {
            Voluntario = voluntario;
            DataInicio = dataInicio;
            DataFinal = dataFinal;
            Motivo = motivo;
        }
        
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public string? Motivo { get; set; }
        public bool Removido { get; set; } = false;
        public int VoluntarioId { get; set; }

        public Voluntario Voluntario { get; set; }
    }
}
