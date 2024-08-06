namespace SistemaNacoes.Application.UseCases.Voluntarios;

public class GetVoluntarioDto
{
    public int Id { get; set; }
    public Guid ChaveAcesso { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
}