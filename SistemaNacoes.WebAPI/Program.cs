using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Application.UseCases.Usuarios;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infrastructure.Persistence.Data;
using SistemaNacoes.Infrastructure.Persistence.Repositorios;
using SistemaNacoes.WebAPI.Mapeamentos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SistemaNacoesDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();
builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();

builder.Services.AddScoped<CriarUsuario>();

builder.Services.AddAutoMapper(typeof(UsuarioProfile));

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
