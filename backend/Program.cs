using Backend.Data;
using Backend.Middleware;
using Scalar.AspNetCore;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructureServices(builder.Configuration, builder.Environment);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();

                IdentitySeed.SeedAsync(scope.ServiceProvider, app.Configuration)
                    .GetAwaiter()
                    .GetResult();

                app.MapOpenApi();
                app.MapScalarApiReference();
                app.MapGet("/", () => Results.Redirect("/scalar"));
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            // Behåll CORS-konfigurationen från master.
            app.UseCors("LocalConnection");

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
