using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.GrupoVoluntario;

public sealed class GrupoVoluntario : EntidadeBase
{
    public GrupoVoluntario()
    {
    }

    public GrupoVoluntario(Grupo.Grupo grupo, Voluntario.Voluntario voluntario)
    {
        Grupo = grupo;
        Voluntario = voluntario;
    }
    
    public int GrupoId { get; set; }
    public int VoluntarioId { get; set; }
    public bool Removido { get; set; } = false;
    
    public Grupo.Grupo Grupo { get; set; }
    public Voluntario.Voluntario Voluntario { get; set; }
}