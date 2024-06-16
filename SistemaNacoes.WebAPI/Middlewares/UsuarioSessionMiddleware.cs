using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Infrastructure.Persistence.Data;

namespace SistemaNacoes.WebAPI.Middlewares
{
    public class UsuarioSessionMiddleware
    {
        private readonly RequestDelegate _next;

        public UsuarioSessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var userId = context.User.FindFirst("UserId")?.Value;

                if (!string.IsNullOrEmpty(userId))
                {
                    using var scope = context.RequestServices.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<SistemaNacoesDbContext>();
                    await dbContext.Database.ExecuteSqlRawAsync($"SET LOCAL \"app.user_id\" = {userId}");
                }
            }

            await _next(context);
        }
    }

    public static class UserSessionMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserSessionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UsuarioSessionMiddleware>();
        }
    }
}
