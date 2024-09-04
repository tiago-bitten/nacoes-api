using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios;

public class DesvinculateVoluntarioMinisterio
{
    private readonly IUnitOfWork _uow;
    private readonly IVoluntarioMinisterioService _voluntarioMinisterioService;
    
    public DesvinculateVoluntarioMinisterio(IUnitOfWork uow, IVoluntarioMinisterioService voluntarioMinisterioService)
    {
        _uow = uow;
        _voluntarioMinisterioService = voluntarioMinisterioService;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(int voluntarioId, int ministerioId)
    {
        var includes = new[]
        {
            nameof(VoluntarioMinisterio.Voluntario),
            nameof(VoluntarioMinisterio.Ministerio)
        };
        
        var voluntarioMinisterio = await _voluntarioMinisterioService.GetAndEnsureExistsAsync(voluntarioId, ministerioId, includes);
        
        _uow.VoluntarioMinisterios.SoftDelete(voluntarioMinisterio);

        /**
         *  Esse código deve ser movido para um serviço de SituacaoAgendamento
         *  Ele 
         */
        /*var situacoesAgendamentos = voluntarioMinisterio.Voluntario.Agendamentos?
            .Where(x => x.MinisterioId == ministerioId && x.Agenda is { Finalizado: false, Ativo: true })
            .Select(x => x.SituacaoAgendamento)
            .ToList();

        if (situacoesAgendamentos != null && situacoesAgendamentos.Any())
            foreach (var situacaoAgendamento in situacoesAgendamentos)
            {
                situacaoAgendamento.Ativo = false;
                situacaoAgendamento.Descricao =
                    $"{voluntarioMinisterio.Voluntario.Nome} não pertence mais ao ministério {voluntarioMinisterio.Ministerio.Nome}";

                _uow.SituacaoAgendamentos.Update(situacaoAgendamento);
            }*/

        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(RespostaBaseMensagem.DesvinculateVoluntarioMinisterio);
        
        return respostaBase;
    }
}