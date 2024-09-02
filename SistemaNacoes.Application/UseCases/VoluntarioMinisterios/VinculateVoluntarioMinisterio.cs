using AutoMapper;
using SistemaNacoes.Application.Dtos.VoluntarioMinisterios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.VoluntarioMinisterios;

public class VinculateVoluntarioMinisterio
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IServiceBase<Voluntario> _voluntarioService;
    private readonly IServiceBase<Ministerio> _ministerioService;

    public VinculateVoluntarioMinisterio(
        IUnitOfWork uow,
        IMapper mapper,
        IServiceBase<Voluntario> voluntarioService,
        IServiceBase<Ministerio> ministerioService)
    {
        _uow = uow;
        _mapper = mapper;
        _voluntarioService = voluntarioService;
        _ministerioService = ministerioService;
    }

    // TODO URGENTE: Refatorar totalmente esse usecase, voluntariominsiterio agora tem identificador unico
    public async Task<RespostaBase<GetSimpVoluntarioMinisterioDto>> ExecuteAsync(VinculateVoluntarioMinisterioDto dto)
    {
        var voluntario = await _voluntarioService.GetAndEnsureExistsAsync(dto.VoluntarioId);
        var ministerio = await _ministerioService.GetAndEnsureExistsAsync(dto.MinisterioId);

        var existingVoluntarioMinisterio = await _uow.VoluntarioMinisterios
            .FindAsync(x => !x.Removido 
                            && x.VoluntarioId == voluntario.Id
                            && x.MinisterioId == ministerio.Id);
        
        if (existingVoluntarioMinisterio != null)
            throw new Exception(MensagemErroConstant.VoluntarioJaPossueMinisterio);

        var voluntarioMinisterio = new VoluntarioMinisterio(voluntario, ministerio);
        await _uow.VoluntarioMinisterios.AddAsync(voluntarioMinisterio);

        await _uow.CommitAsync();

        var respostaBase = new RespostaBase<GetSimpVoluntarioMinisterioDto>(
            MensagemRepostaConstant.VinculateVoluntarioMinisterio);

        return respostaBase;
    }
}