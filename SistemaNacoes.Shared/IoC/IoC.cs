using Microsoft.Extensions.DependencyInjection;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Repositories;

namespace SistemaNacoes.Shared.IoC
{
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
    }
}
