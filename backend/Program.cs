using Backend.Data;
using Backend.Middleware;
using Scalar.AspNetCore;

namespace Backend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructureServices(
                builder.Configuration);

            // WithViews krävs för ValidateAntiForgeryToken.
            builder.Services.AddControllersWithViews();
            builder.Services.AddProblemDetails();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();

                await IdentitySeed.SeedAsync(
                    scope.ServiceProvider,
                    app.Configuration);

                app.MapOpenApi();
                app.MapScalarApiReference();
                app.MapGet(
                    "/",
                    () => Results.Redirect("/scalar"));
            }

            app.UseHttpsRedirection();

            // Behåll CORS-konfigurationen från master.
            app.UseCors("LocalConnection");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}