using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Grupo
{
    public sealed class Grupo : EntidadeBase
    {
        public Grupo() {}
        public Grupo(string nome)
        {
            Nome = nome;
        }
        
        public Grupo(string nome, Ministerio.Ministerio ministerioPreferencial)
        {
            Nome = nome;
            MinisterioPreferencial = ministerioPreferencial;
        }
        
        public string Nome { get; set; }
        public bool Removido { get; set; } = false;
        public int? MinisterioPreferencialId { get; set; }

        public Ministerio.Ministerio? MinisterioPreferencial { get; set; }
        public List<GrupoVoluntario.GrupoVoluntario> GrupoVoluntarios { get; set; } = new();
    }
}
