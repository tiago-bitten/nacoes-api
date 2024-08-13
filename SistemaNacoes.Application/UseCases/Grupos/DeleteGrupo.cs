using AutoMapper;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Grupos;

public class DeleteGrupo
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IServiceBase<Grupo> _grupoService;
    
    public DeleteGrupo(IUnitOfWork uow, IMapper mapper, IServiceBase<Grupo> grupoService)
    {
        _uow = uow;
        _mapper = mapper;
        _grupoService = grupoService;
    }

    public async Task<RespostaBase<dynamic>> ExecuteAsync(int id)
    {
        var grupo = await _grupoService.GetAndEnsureExistsAsync(id);
        
        _uow.Grupos.SoftDeleteAsync(grupo);
        await _uow.CommitAsync();
        
        var respostaBase = new RespostaBase<dynamic>(MensagemRepostasConstant.DeleteGrupo);
        
        return respostaBase;
    }
}