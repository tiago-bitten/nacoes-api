namespace SistemaNacoes.Domain.Entidades
{
    public class Voluntario : EntidadeBase
    {
        public Voluntario(string nome, string email, string cpf, DateTime dataNascimento, Grupo grupo)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Grupo = grupo;
            GrupoId = grupo.Id;
        }
        
        public Guid ChaveAcesso { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? GrupoId { get; set; }
        public bool Removido { get; set; } = false;

        public Grupo? Grupo { get; set; }

        public List<VoluntarioMinisterio> VoluntariosMinisterios { get; set; } = new();
        public List<Agendamento> Agendamentos { get; set; } = new();
        public List<DataIndisponivel> DatasIndisponiveis { get; set; } = new();
        public List<EscalaItem> EscalaItens { get; set; } = new();
    }
}
