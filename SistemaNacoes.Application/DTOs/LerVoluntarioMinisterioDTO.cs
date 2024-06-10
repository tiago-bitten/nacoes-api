namespace SistemaNacoes.Application.DTOs
{
    internal class LerVoluntarioMinisterioDTO
    {
        public LerVoluntarioDTO Voluntario { get; set; }
        public LerMinisterioDTO Ministerio { get; set; }
        public bool Ativo { get; set; }
    }
}
