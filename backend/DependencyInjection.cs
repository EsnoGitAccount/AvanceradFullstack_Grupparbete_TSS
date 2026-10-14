using Backend.Data;
using Backend.Model;
using Backend.Options;
using Azure.Storage.Blobs;
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

            //Blob
			services.AddOptions<BlobStorageOptions>()
				.BindConfiguration("AzureBlobStorage");

			// Identity
			services.AddIdentity<User, IdentityRole<int>>()
              .AddEntityFrameworkStores<WhereAreWeDbContext>()
              .AddDefaultTokenProviders();

            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: "LocalConnection",
                        policy =>
                        {
                            policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                        }
                );
            });

			// Repositories
			services.AddScoped<ICityRepository, CityRepository>();
			services.AddSingleton<IBlobStorageService, BlobStorageService>();
			services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IDailyChallengeRepository, DailyChallengeRepository>();

            // Services
			services.AddScoped<ICityService, CityService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IDailyChallengeService, DailyChallengeService>();

            // JWT

            return services;
        }
    }
}
