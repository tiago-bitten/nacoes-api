using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class VoluntarioMinisterio : EntidadeBase
    {
        public VoluntarioMinisterio() {}
        public VoluntarioMinisterio(Voluntario voluntario, Ministerio.Ministerio ministerio)
        {
            Voluntario = voluntario;
            Ministerio = ministerio;
        }   
        
        public int VoluntarioId { get; set; }
        public int MinisterioId { get; set; }
        public bool Removido { get; set; } = false;

        public Voluntario Voluntario { get; set; }
        public Ministerio.Ministerio Ministerio { get; set; }
    }
}


