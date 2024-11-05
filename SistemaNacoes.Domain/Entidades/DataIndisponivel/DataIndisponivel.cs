using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.DataIndisponivel;

public sealed class DataIndisponivel : EntidadeBase
{
    public DateTime DataInicio { get; set; }
    public DateTime DataFinal { get; set; }
    public string? Motivo { get; set; }
    public bool Suspenso { get; private set; } = false;
    public int VoluntarioId { get; set; }

    public Voluntario.Voluntario Voluntario { get; set; }
        
    #region Ctor
    public DataIndisponivel() {}
    public DataIndisponivel(Voluntario.Voluntario voluntario, DateTime dataInicio, DateTime dataFinal)
    {
        Voluntario = voluntario;
        DataInicio = dataInicio;
        DataFinal = dataFinal;
    }
        
    public DataIndisponivel(Voluntario.Voluntario voluntario, DateTime dataInicio, DateTime dataFinal, string motivo)
    {
        Voluntario = voluntario;
        DataInicio = dataInicio;
        DataFinal = dataFinal;
        Motivo = motivo;
    }
    #endregion
    
    #region Suspender
    public void Suspender()
    {
        Suspenso = true;
    }
    #endregion
}