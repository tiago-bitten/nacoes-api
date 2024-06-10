namespace SistemaNacoes.Application.DTOs
{
    public class LerAgendaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public bool? Ativo { get; set; }
    }
}
