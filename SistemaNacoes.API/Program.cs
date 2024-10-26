using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaNacoes.Application.Profiles;
using SistemaNacoes.Application.Services;
using SistemaNacoes.Application.UseCases.Agendamentos;
using SistemaNacoes.Application.UseCases.Agendamentos.CriarAgendamento;
using SistemaNacoes.Application.UseCases.Agendamentos.RemoverAgendamento;
using SistemaNacoes.Application.UseCases.Agendas;
using SistemaNacoes.Application.UseCases.Atividades;
using SistemaNacoes.Application.UseCases.Auth;
using SistemaNacoes.Application.UseCases.DataIndisponiveis;
using SistemaNacoes.Application.UseCases.Grupos;
using SistemaNacoes.Application.UseCases.GrupoVoluntarios;
using SistemaNacoes.Application.UseCases.Ministerios;
using SistemaNacoes.Application.UseCases.Permissoes;
using SistemaNacoes.Application.UseCases.UsuarioMinisterios;
using SistemaNacoes.Application.UseCases.Usuarios;
using SistemaNacoes.Application.UseCases.VoluntarioMinisterios;
using SistemaNacoes.Application.UseCases.Voluntarios;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Infra.Contexts;
using SistemaNacoes.Infra.Data;
using SistemaNacoes.Infra.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NacoesDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// TODO: mover para um arquivo de configuração
#region jwt config
builder.Services.AddAuthentication(options => 
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        }; 
    });
#endregion

#region http context
builder.Services.AddHttpContextAccessor();
#endregion

#region repositorios/services
builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();
builder.Services.AddScoped<IAtividadeRepository, AtividadeRepository>();
builder.Services.AddScoped<IDataIndisponivelRepository, DataIndisponivelRepository>();
builder.Services.AddScoped<IEscalaItemRepository, EscalaItemRepository>();
builder.Services.AddScoped<IEscalaRepository, EscalaRepository>();
builder.Services.AddScoped<IGrupoRepository, GrupoRepository>();
builder.Services.AddScoped<IMinisterioRepository, MinisterioRepository>();
builder.Services.AddScoped<IUsuarioMinisterioRepository, UsuarioMinisterioRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVoluntarioRepository, VoluntarioRepository>();
builder.Services.AddScoped<IVoluntarioMinisterioRepository, VoluntarioMinisterioRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAgendamentoAtividadeRepository, AgendamentoAtividadeRepository>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IVoluntarioService, VoluntarioService>();
builder.Services.AddScoped<IVoluntarioMinisterioService, VoluntarioMinisterioService>();
builder.Services.AddScoped<IAgendaService, AgendaService>();
builder.Services.AddScoped<ISituacaoAgendamentoRepository, SituacaoAgendamentoRepository>();
builder.Services.AddScoped<IDataIndisponivelService, DataIndisponivelService>();
builder.Services.AddScoped<IMinisterioService, MinisterioService>();
builder.Services.AddScoped<IGrupoVoluntarioRepository, GrupoVoluntarioRepository>();
builder.Services.AddScoped<IAgendamentoAtividadeService, AgendamentoAtividadeService>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<ITokenService, JsonWebTokenService>();
builder.Services.AddScoped<IAmbienteUsuarioService, AmbienteUsuarioService>();
builder.Services.AddScoped<IHistoricoLoginRepository, HistoricoLoginRepository>();
builder.Services.AddScoped<IHistoricoLoginService, HistoricoLoginService>();
builder.Services.AddScoped<IHistoricoEntidadeRepository, HistoricoEntidadeRepository>();
builder.Services.AddScoped<IHistoricoEntidadeService, HistoricoEntidadeService>();
builder.Services.AddScoped<IAtividadeService, AtividadeService>();
#endregion


#region automapper profiles
builder.Services.AddAutoMapper(typeof(VoluntarioProfile));
builder.Services.AddAutoMapper(typeof(MinisterioProfile));
builder.Services.AddAutoMapper(typeof(VoluntarioMinisterioProfile));
builder.Services.AddAutoMapper(typeof(AgendaProfile));
builder.Services.AddAutoMapper(typeof(DataIndisponivelProfile));
builder.Services.AddAutoMapper(typeof(AtividadeProfile));
builder.Services.AddAutoMapper(typeof(AgendamentoProfile));
builder.Services.AddAutoMapper(typeof(GrupoProfile));
builder.Services.AddAutoMapper(typeof(AuthTokenProfile));
builder.Services.AddAutoMapper(typeof(UsuarioProfile));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();