using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.Profiles;
using SistemaNacoes.Application.Services;
using SistemaNacoes.Application.UseCases.Agendamentos;
using SistemaNacoes.Application.UseCases.Agendas;
using SistemaNacoes.Application.UseCases.Atividades;
using SistemaNacoes.Application.UseCases.DataIndisponiveis;
using SistemaNacoes.Application.UseCases.Grupos;
using SistemaNacoes.Application.UseCases.Ministerios;
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
builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
builder.Services.AddScoped<IVoluntarioService, VoluntarioService>();
builder.Services.AddScoped<IVoluntarioMinisterioService, VoluntarioMinisterioService>();
builder.Services.AddScoped<IAgendaService, AgendaService>();
builder.Services.AddScoped<ISituacaoAgendamentoRepository, SituacaoAgendamentoRepository>();
builder.Services.AddScoped<IDataIndisponivelService, DataIndisponivelService>();
builder.Services.AddScoped<IMinisterioService, MinisterioService>();
builder.Services.AddScoped<IGrupoVoluntarioRepository, GrupoVoluntarioRepository>();
builder.Services.AddScoped<IAgendamentoAtividadeService, AgendamentoAtividadeService>();

builder.Services.AddScoped<CreateVoluntario>();
builder.Services.AddScoped<CreateMinisterio>();
builder.Services.AddScoped<CreateDataIndisponivel>();
builder.Services.AddScoped<CreateAtividade>();
builder.Services.AddScoped<GetAllVoluntarios>();
builder.Services.AddScoped<CreateAgendamento>();
builder.Services.AddScoped<GetAllVoluntarioMinisterios>();
builder.Services.AddScoped<GetAllMinisterios>();
builder.Services.AddScoped<GetAllAtividades>();
builder.Services.AddScoped<GetAllAgendas>();
builder.Services.AddScoped<GetAllDataIndisponiveis>();
builder.Services.AddScoped<GetAllAgendamentos>();
builder.Services.AddScoped<VinculateVoluntarioMinisterio>();
builder.Services.AddScoped<OpenAgenda>();
builder.Services.AddScoped<CloseAgenda>();
builder.Services.AddScoped<FinalizeAgenda>();
builder.Services.AddScoped<DeleteAgendamento>();
builder.Services.AddScoped<DeleteVoluntario>();
builder.Services.AddScoped<DeleteAtividade>();
builder.Services.AddScoped<SuspendDataIndisponivel>();
builder.Services.AddScoped<DeleteMinisterio>();
builder.Services.AddScoped<CreateGrupo>();
builder.Services.AddScoped<GetAllGrupos>();
builder.Services.AddScoped<DeleteGrupo>();
builder.Services.AddScoped<DesvinculateVoluntarioMinisterio>();
builder.Services.AddScoped<DeleteMinisterio>();
builder.Services.AddScoped<VinculateVoluntarioGrupo>();
builder.Services.AddScoped<VinculateAgendamentoAtividade>();
builder.Services.AddScoped<DeleteAgendamentoAtividade>();
builder.Services.AddScoped<GetVoluntariosParaAgendar>();

builder.Services.AddAutoMapper(typeof(VoluntarioProfile));
builder.Services.AddAutoMapper(typeof(MinisterioProfile));
builder.Services.AddAutoMapper(typeof(VoluntarioMinisterioProfile));
builder.Services.AddAutoMapper(typeof(AgendaProfile));
builder.Services.AddAutoMapper(typeof(DataIndisponivelProfile));
builder.Services.AddAutoMapper(typeof(AtividadeProfile));
builder.Services.AddAutoMapper(typeof(AgendamentoProfile));
builder.Services.AddAutoMapper(typeof(SituacaoAgendamentoProfile));
builder.Services.AddAutoMapper(typeof(GrupoProfile));

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