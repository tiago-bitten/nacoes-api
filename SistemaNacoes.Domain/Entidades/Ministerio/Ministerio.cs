using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Ministerio
{
    public sealed class Ministerio : EntidadeBase
    {
        public Ministerio() {}
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }

        public List<Atividade.Atividade> Atividades { get; set; } = new();
        public List<VoluntarioMinisterio> VoluntarioMinisterios { get; set; } = new();
        public List<UsuarioMinisterio.UsuarioMinisterio> UsuariosMinisterios { get; set; } = new();
        public List<Agendamento.Agendamento> Agendamentos { get; set; } = new();
        public List<Escala.Escala> Escalas { get; set; } = new();
        public List<Grupo.Grupo> Grupos { get; set; } = new();
    }
}