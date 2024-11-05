using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Voluntario;

public class VoluntarioService : ServiceBase<Voluntario, IVoluntarioRepository>, IVoluntarioService
{
    public VoluntarioService(IVoluntarioRepository repository)
        : base(repository)
    {
    }

    #region RecuperarPorChaveAcessoAsync
    public async Task<Voluntario> RecuperarPorChaveAcessoAsync(Guid chaveAcesso, params string[]? includes)
    {
        var existe = await Repository.RecuperarPorChaveAcessoAsync(chaveAcesso, includes);
        
        if (existe is null)
            throw new NacoesAppException("Forneça uma chave de acesso válida");

        return existe;
    }
    #endregion

    #region GaranteNaoExisteCadastradoAsync
    public async Task GaranteNaoExisteCadastradoAsync(string? cpf)
    {
        if (string.IsNullOrEmpty(cpf))
            return;
        
        var existe = await Repository.RecuperarPorCpfAsync(cpf);
            
        if (existe is not null)
            throw new NacoesAppException("Voluntário com cpf já cadastrado.");
    }
    #endregion

    #region RecuperarParaAgendar
    public IQueryable<Voluntario> RecuperarParaAgendar(int agendaId, int ministerioId)
    {
        return Repository.RecuperarParaAgendar(agendaId, ministerioId);
    }
    #endregion
}