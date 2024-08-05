namespace SistemaNacoes.Domain.Entidades
{
    public class VoluntarioMinisterio
    {
        public VoluntarioMinisterio(Voluntario voluntario, Ministerio ministerio)
        {
            Voluntario = voluntario;
            Ministerio = ministerio;
        }   
        
        public int VoluntarioId { get; set; }
        public int MinisterioId { get; set; }
        public bool Ativo { get; set; } = true;

        public Voluntario Voluntario { get; set; }
        public Ministerio Ministerio { get; set; }
    }
}
