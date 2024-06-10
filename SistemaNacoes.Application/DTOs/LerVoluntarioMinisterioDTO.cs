namespace SistemaNacoes.Application.DTOs
{
    public class LerVoluntarioMinisterioDTO
    {
        public LerVoluntarioDTO Voluntario { get; set; }
        public LerMinisterioDTO Ministerio { get; set; }
        public bool Ativo { get; set; }
    }
}
