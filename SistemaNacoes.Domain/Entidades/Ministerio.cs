using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class Ministerio : EntidadeBase
    {
        public Ministerio() {}
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }

        public List<Atividade> Atividades { get; set; } = new();
        public List<VoluntarioMinisterio> VoluntarioMinisterios { get; set; } = new();
        public List<UsuarioMinisterio> UsuariosMinisterios { get; set; } = new();
        public List<Agendamento.Agendamento> Agendamentos { get; set; } = new();
        public List<Escala> Escalas { get; set; } = new();
        public List<Grupo> Grupos { get; set; } = new();
    }
}