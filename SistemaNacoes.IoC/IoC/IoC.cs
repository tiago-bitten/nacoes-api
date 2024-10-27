using Microsoft.Extensions.DependencyInjection;
using SistemaNacoes.Application.Services;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Infra.Repositorios;

namespace SistemaNacoes.IoC.IoC;

public static class IoC
{
    public static IServiceCollection AdicionarRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

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

    public static IServiceCollection AdicionarServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<,>));

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
}