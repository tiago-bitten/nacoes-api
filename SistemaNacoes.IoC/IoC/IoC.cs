using Microsoft.Extensions.DependencyInjection;
using SistemaNacoes.Application.Profiles;
using SistemaNacoes.Application.Services;
using SistemaNacoes.Application.UseCases.AgendamentoAtividade.CriarAgendamentoAtividade;
using SistemaNacoes.Application.UseCases.AgendamentoAtividades.CriarAgendamentoAtividade;
using SistemaNacoes.Application.UseCases.AgendamentoAtividades.RemoverAgendamentoAtividade;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;
using SistemaNacoes.Application.UseCases.Agendamentos.RemoverAgendamento;
using SistemaNacoes.Application.UseCases.Agendas.AbrirAgenda;
using SistemaNacoes.Application.UseCases.Agendas.ConcluirAgenda;
using SistemaNacoes.Application.UseCases.Agendas.ListarAgenda;
using SistemaNacoes.Application.UseCases.Agendas.RemoverAgenda;
using SistemaNacoes.Application.UseCases.Atividades.CriarAtividade;
using SistemaNacoes.Application.UseCases.Atividades.ListarAtividade;
using SistemaNacoes.Application.UseCases.Atividades.RemoverAtividade;
using SistemaNacoes.Application.UseCases.Auth.Entrar;
using SistemaNacoes.Application.UseCases.Auth.RefreshToken;
using SistemaNacoes.Application.UseCases.DataIndisponiveis.CriarDataIndisponivel;
using SistemaNacoes.Application.UseCases.DataIndisponiveis.RemoverDataIndisponivel;
using SistemaNacoes.Application.UseCases.DataIndisponiveis.SuspenderDataIndisponivel;
using SistemaNacoes.Application.UseCases.Grupos.CriarGrupo;
using SistemaNacoes.Application.UseCases.Grupos.RemoverGrupo;
using SistemaNacoes.Application.UseCases.GrupoVoluntarios.CriarGrupoVoluntario;
using SistemaNacoes.Application.UseCases.Ministerios.CriarMinisterio;
using SistemaNacoes.Application.UseCases.Ministerios.RemoverMinisterio;
using SistemaNacoes.Application.UseCases.Permissoes.AdicionarPermissao;
using SistemaNacoes.Application.UseCases.Permissoes.ListarPermissoes;
using SistemaNacoes.Application.UseCases.Permissoes.RemoverPermissao;
using SistemaNacoes.Application.UseCases.UsuarioMinisterios.CriarUsuarioMinisterio;
using SistemaNacoes.Application.UseCases.Usuarios.CriarUsuario;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.CriarVoluntarioMinisterio;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.ListarVoluntarioMinisterio;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios.RemoverVoluntarioMinisterio;
using SistemaNacoes.Application.UseCases.Voluntarios.CriarVoluntario;
using SistemaNacoes.Application.UseCases.Voluntarios.ListarVoluntario;
using SistemaNacoes.Application.UseCases.Voluntarios.RecuperarVoluntarioParaAgendar;
using SistemaNacoes.Application.UseCases.Voluntarios.RemoverVoluntario;
using SistemaNacoes.Domain.Entidades.Agenda;
using SistemaNacoes.Domain.Entidades.Agendamento;
using SistemaNacoes.Domain.Entidades.AgendamentoAtividade;
using SistemaNacoes.Domain.Entidades.Atividade;
using SistemaNacoes.Domain.Entidades.DataIndisponivel;
using SistemaNacoes.Domain.Entidades.Escala;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Infra.Data;
using SistemaNacoes.Infra.Repositorios;

namespace SistemaNacoes.IoC.IoC;

public static class IoC
{
    #region Repositories
    public static IServiceCollection AdicionarRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
        services.AddScoped<IAgendamentoAtividadeRepository, AgendamentoAtividadeRepository>();
        services.AddScoped<IAgendaRepository, AgendaRepository>();
        services.AddScoped<IAtividadeRepository, AtividadeRepository>();
        services.AddScoped<IDataIndisponivelRepository, DataIndisponivelRepository>();
        services.AddScoped<IEscalaItemRepository, EscalaItemRepository>();
        services.AddScoped<IEscalaRepository, EscalaRepository>();
        services.AddScoped<IGrupoRepository, GrupoRepository>();
        services.AddScoped<IGrupoVoluntarioRepository, GrupoVoluntarioRepository>();
        services.AddScoped<IHistoricoEntidadeRepository, HistoricoEntidadeRepository>();
        services.AddScoped<IHistoricoLoginRepository, HistoricoLoginRepository>();
        services.AddScoped<IMinisterioRepository, MinisterioRepository>();
        services.AddScoped<IPerfilAcessoRepository, PerfilAcessoRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUsuarioMinisterioRepository, UsuarioMinisterioRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IVoluntarioMinisterioRepository, VoluntarioMinisterioRepository>();
        services.AddScoped<IVoluntarioRepository, VoluntarioRepository>();

        return services;
    }
    #endregion

    #region Services
    public static IServiceCollection AdicionarServices(this IServiceCollection services)
    {
        services.AddScoped<IAgendamentoAtividadeService, AgendamentoAtividadeService>();
        services.AddScoped<IAgendamentoService, AgendamentoService>();
        services.AddScoped<IAgendaService, AgendaService>();
        services.AddScoped<IAmbienteUsuarioService, AmbienteUsuarioService>();
        services.AddScoped<IAtividadeService, AtividadeService>();
        services.AddScoped<IDataIndisponivelService, DataIndisponivelService>();
        services.AddScoped<IGrupoService, GrupoService>();
        services.AddScoped<IGrupoVoluntarioService, GrupoVoluntarioService>();
        services.AddScoped<IHistoricoEntidadeService, HistoricoEntidadeService>();
        services.AddScoped<IHistoricoLoginService, HistoricoLoginService>();
        services.AddScoped<ITokenService, JsonWebTokenService>();
        services.AddScoped<IMinisterioService, MinisterioService>();
        services.AddScoped<IPerfilAcessoService, PerfilAcessoService>();
        services.AddScoped<IPermissoesService, PermissoesService>();
        services.AddScoped<IUsuarioMinisterioService, UsuarioMinisterioService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IVoluntarioMinisterioService, VoluntarioMinisterioService>();
        services.AddScoped<IVoluntarioService, VoluntarioService>();

        return services;
    }
    #endregion
    
    #region UseCases

    public static IServiceCollection AdicionarUseCases(this IServiceCollection services)
    {
        #region AgendamentoAtividade
        services.AddScoped<ICriarAgendamentoAtividadeUseCase, CriarAgendamentoAtividade>();
        services.AddScoped<IRemoverAgendamentoAtividadeUseCase, RemoverAgendamentoAtividade>();
        #endregion

        #region Agendamento
        services.AddScoped<ICriarAgendamentoUseCase, CriarAgendamento>();
        services.AddScoped<IRemoverAgendamentoUseCase, RemoverAgendamento>();
        #endregion
        
        #region Agenda
        services.AddScoped<IAbrirAgendaUseCase, AbrirAgenda>();
        services.AddScoped<IConcluirAgendaUseCase, ConcluirAgenda>();
        services.AddScoped<IListarAgendaUseCase, ListarAgenda>();
        services.AddScoped<IRemoverAgendaUseCase, RemoverAgenda>();
        #endregion
        
        #region Atividade
        services.AddScoped<ICriarAtividadeUseCase, CriarAtividade>();
        services.AddScoped<IRemoverAtividadeUseCase, RemoverAtividade>();
        services.AddScoped<IListarAtividadeUseCase, ListarAtividade>();
        #endregion
        
        #region Auth
        services.AddScoped<IEntrarUseCase, Entrar>();
        services.AddScoped<IRefreshTokenUseCase, RefreshTokens>();
        #endregion
        
        #region DataIndisponivel
        services.AddScoped<ICriarDataIndisponivelUseCase, CriarDataIndisponivel>();
        services.AddScoped<IRemoverDataIndisponivelUseCase, RemoverDataIndisponivel>();
        services.AddScoped<ISuspenderDataIndisponivelUseCase, SuspenderDataIndisponivel>();
        #endregion
        
        #region Grupo
        services.AddScoped<ICriarGrupoUseCase, CriarGrupo>();
        services.AddScoped<IRemoverGrupoUseCase, RemoverGrupo>();
        #endregion
        
        #region GrupoVoluntario
        services.AddScoped<ICriarGrupoVoluntarioUseCase, CriarGrupoVoluntario>();
        #endregion
        
        #region Ministerio
        services.AddScoped<ICriarMinisterioUseCase, CriarMinisterio>();
        services.AddScoped<IRemoverMinisterioUseCase, RemoverMinisterio>();
        #endregion
        
        #region Permissoes
        services.AddScoped<IAdicionarPermissaoUseCase, AdicionarPermissao>();
        services.AddScoped<IListarPermissoesUseCase, ListarPermissoes>();
        services.AddScoped<IRemoverPermissaoUseCase, RemoverPermissao>();
        #endregion
        
        #region UsuarioMinisterio
        services.AddScoped<ICriarUsuarioMinisterioUseCase, CriarUsuarioMinisterio>();
        #endregion
        
        #region Usuario
        services.AddScoped<ICriarUsuarioUseCase, CriarUsuario>();
        #endregion
        
        #region VoluntarioMinisterio
        services.AddScoped<ICriarVoluntarioMinisterioUseCase, CriarVoluntarioMinisterio>();
        services.AddScoped<IListarVoluntarioMinisterioUseCase, ListarVoluntarioMinisterio>();
        services.AddScoped<IRemoverVoluntarioMinisterioUseCase, RemoverVoluntarioMinisterio>();
        #endregion
        
        #region Volutnario
        services.AddScoped<ICriarVoluntarioUseCase, CriarVoluntario>();
        services.AddScoped<IListarVoluntarioUseCase, ListarVoluntario>();
        services.AddScoped<IRemoverVoluntarioUseCase, RemoverVoluntario>();
        services.AddScoped<IRecuperarVoluntarioParaAgendarUseCase, RecuperarVoluntarioParaAgendar>();
        #endregion

        return services;
    }
    #endregion
    
    #region Profiles
    public static IServiceCollection AdicionarProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(VoluntarioProfile));
        services.AddAutoMapper(typeof(MinisterioProfile));
        services.AddAutoMapper(typeof(VoluntarioMinisterioProfile));
        services.AddAutoMapper(typeof(AgendaProfile));
        services.AddAutoMapper(typeof(DataIndisponivelProfile));
        services.AddAutoMapper(typeof(AtividadeProfile));
        services.AddAutoMapper(typeof(AgendamentoProfile));
        services.AddAutoMapper(typeof(GrupoProfile));
        services.AddAutoMapper(typeof(AuthTokenProfile));
        services.AddAutoMapper(typeof(UsuarioProfile));

        return services;
    }
    #endregion
}