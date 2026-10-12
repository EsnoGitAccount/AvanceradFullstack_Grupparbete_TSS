using Backend.Data;
using Backend.Model;
using Backend.Repositories;
using Backend.Repositories.IRepositories;
using Backend.Services;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    /// <summary>
    /// Extension method for configuring infrastructure services including DbContext, 
    /// Identity, repositories, and business services.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WhereAreWeDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.EnableRetryOnFailure()));

            // Identity
            services.AddIdentity<User, IdentityRole<int>>()
              .AddEntityFrameworkStores<WhereAreWeDbContext>()
              .AddDefaultTokenProviders();

            // Repositories
            services.AddScoped<ICityReposistory, CityRepository>();
            services.AddScoped<IGameRepository, GameRepository>();

            // Services
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IGameService, GameService>();

            // JWT

            return services;
        }
    }
}
