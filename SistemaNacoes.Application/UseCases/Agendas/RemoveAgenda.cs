using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendas;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendas
{
    public class RemoveAgenda
    {
        private readonly IUnitOfWork _uow;
        private readonly IServiceBase<Agenda> _agendaService;

        public RemoveAgenda(IUnitOfWork uow, IServiceBase<Agenda> agendaService)
        {
            _uow = uow;
            _agendaService = agendaService;
        }

        public async Task<RespostaBase<dynamic>> ExecuteAsync(CloseAgendaDto dto)
        {
            var agenda = await _agendaService.RecuperaGaranteExisteAsync(dto.Id);
            
            agenda.Remover();
            
            _uow.Agendas.Atualizar(agenda);
            await _uow.CommitAsync();

            var respostaBase = new RespostaBase<dynamic>(
                RespostaBaseMensagem.RemoveAgenda);

            return respostaBase;
        }
    }
}
