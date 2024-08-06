namespace SistemaNacoes.Application.Dtos.Voluntarios;

public class CreateVoluntarioDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string? Cpf { get; set; }
    public DateTime? DataNascimento { get; set; }
}