namespace SistemaNacoes.Domain.Entidades
{
    public class Ministerio : EntidadeBase
    {
        public Ministerio() {}
        public Ministerio(string nome, string descricao, string cor)
        {
            Nome = nome;
            Descricao = descricao;
            Cor = cor;
        }
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public bool Removido { get; set; } = false;

        public List<Atividade> Atividades { get; set; } = new();
        public List<VoluntarioMinisterio> VoluntarioMinisterios { get; set; } = new();
        public List<UsuarioMinisterio> UsuariosMinisterios { get; set; } = new();
        public List<Agendamento> Agendamentos { get; set; } = new();
        public List<Escala> Escalas { get; set; } = new();
        public List<Grupo> Grupos { get; set; } = new();
    }
}