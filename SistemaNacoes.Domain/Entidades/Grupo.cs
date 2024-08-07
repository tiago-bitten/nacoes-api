namespace SistemaNacoes.Domain.Entidades
{
    public class Grupo : EntidadeBase
    {
        public Grupo() {}
        public Grupo(string nome)
        {
            Nome = nome;
        }
        
        public Grupo(string nome, Ministerio ministerioPreferencial)
        {
            Nome = nome;
            MinisterioPreferencial = ministerioPreferencial;
        }
        
        public string Nome { get; set; }
        public bool Removido { get; set; } = false;
        public int? MinisterioPreferencialId { get; set; }

        public Ministerio? MinisterioPreferencial { get; set; }
        public List<Voluntario> Voluntarios { get; set; } = new();
    }
}
