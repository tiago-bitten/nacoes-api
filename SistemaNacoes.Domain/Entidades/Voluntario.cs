namespace SistemaNacoes.Domain.Entidades
{
    public class Voluntario : EntidadeBase
    {
        public Voluntario() {}
        
        public Voluntario(string nome, string email, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }
        
        public Guid ChaveAcesso { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool Removido { get; set; } = false;

        public List<GrupoVoluntario> GrupoVoluntarios { get; set; } = new();

        public List<VoluntarioMinisterio> VoluntarioMinisterios { get; set; } = new();
        public List<Agendamento> Agendamentos { get; set; } = new();
        public List<DataIndisponivel> DatasIndisponiveis { get; set; } = new();
        public List<EscalaItem> EscalaItens { get; set; } = new();
    }
}
