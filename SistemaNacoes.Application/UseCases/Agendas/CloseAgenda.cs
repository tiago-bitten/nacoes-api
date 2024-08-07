using AutoMapper;
using SistemaNacoes.Application.Dtos.Agendas;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Agendas
{
    public class CloseAgenda
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IServiceBase<Agenda> _agendaService;

        public CloseAgenda(IUnitOfWork uow, IMapper mapper, IServiceBase<Agenda> agendaService)
        {
            _uow = uow;
            _mapper = mapper;
            _agendaService = agendaService;
        }

        public async Task<RespostaBase<GetAgendaDto>> ExecuteAsync(CloseAgendaDto dto)
        {
            var agenda = await _agendaService.GetAndValidateEntityAsync(dto.Id);

            agenda.Close();
            _uow.Agendas.Update(agenda);
            await _uow.CommitAsync();

            var agendaDto = _mapper.Map<GetAgendaDto>(agenda);

            var respostaBase = new RespostaBase<GetAgendaDto>(MensagemRepostasConstant.CloseAgenda, agendaDto);

            return respostaBase;
        }
    }
}
