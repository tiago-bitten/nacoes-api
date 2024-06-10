namespace SistemaNacoes.Application.DTOs
{
    public class LerDataIndisponivelDTO
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public LerVoluntarioDTO voluntario { get; set; }
    }
}
