namespace SistemaNacoes.Domain.Entidades;

public sealed class GrupoVoluntario
{
    public GrupoVoluntario()
    {
    }

    public GrupoVoluntario(Grupo grupo, Voluntario voluntario)
    {
        Grupo = grupo;
        Voluntario = voluntario;
    }
    
    public int GrupoId { get; set; }
    public int VoluntarioId { get; set; }
    public bool Removido { get; set; } = false;
    
    public Grupo Grupo { get; set; }
    public Voluntario Voluntario { get; set; }
}