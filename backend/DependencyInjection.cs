using Backend.Data;
using Backend.Model;
using Backend.Options;
using Azure.Storage.Blobs;
using Backend.Repositories;
using Backend.Repositories.IRepositories;
using Backend.Services;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;


namespace Backend
{
    /// <summary>
    /// Extension method for configuring infrastructure services including DbContext, 
    /// Identity, repositories, and business services.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {

            services.AddDbContext<WhereAreWeDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.EnableRetryOnFailure()));

            // Blob storage
            services.AddOptions<BlobStorageOptions>()
                .BindConfiguration("AzureBlobStorage");

            // Identity
            services.AddIdentity<User, IdentityRole<int>>()
              .AddEntityFrameworkStores<WhereAreWeDbContext>()
              .AddDefaultTokenProviders();

            // Repositories
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IDailyChallengeRepository, DailyChallengeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Blob storage service
            services.AddSingleton<IBlobStorageService, BlobStorageService>();

            // CORS
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

            // ASP.NET Core services
            services.AddControllersWithViews();
            services.AddProblemDetails();
            services.AddOpenApi();

            // Application services
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IDailyChallengeService, DailyChallengeService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICookieService, CookieService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILeaderboardService, LeaderboardService>();

            // JWT
            var jwtIssuer = configuration["Jwt:Issuer"] ??
                throw new InvalidOperationException("Jwt:Issuer is missing.");

            var jwtAudience = configuration["Jwt:Audience"] ??
                throw new InvalidOperationException("Jwt:Audience is missing.");

            var jwtSigningKey = configuration["Jwt:SigningKey"] ??
                throw new InvalidOperationException("Jwt:SigningKey is missing.");

            // Ensure the signing key is at least 32 bytes for HMAC-SHA256
            if (Encoding.UTF8.GetByteCount(jwtSigningKey) < 32)
            {
                throw new InvalidOperationException("Jwt:SigningKey must contain at least 32 bytes.");
            }

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                    options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(options =>
                {
                    options.MapInboundClaims = false; 

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtIssuer,

                        ValidateAudience = true,
                        ValidAudience = jwtAudience,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSigningKey)),

                        ValidateLifetime = true,
                        RequireExpirationTime = true,

                        // Allow only HMAC-SHA256 for signing
                        ValidAlgorithms = [SecurityAlgorithms.HmacSha256],

                        NameClaimType = ClaimTypes.Name,
                        RoleClaimType = ClaimTypes.Role,

                        // Allow a small clock skew to account for server time differences
                        ClockSkew = TimeSpan.FromSeconds(30)
                    };

                    // Custom event to read the JWT token from cookies
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            // Check for the access token in cookies
                            if (context.Request.Cookies.TryGetValue("accessToken", out var accessToken))
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization();

            services.AddAntiforgery(options =>
            {
                // Header name can be whatever if we want something else, this is just standard
                options.HeaderName = "X-XSRF-TOKEN";

                var c = options.Cookie;

                c.Name = "Antiforgery";
                c.HttpOnly = true;
                c.SecurePolicy = CookieSecurePolicy.Always;
                c.SameSite = environment.IsDevelopment()
                    ? SameSiteMode.None
                    : SameSiteMode.Lax;
                c.Path = "/";
            });


            return services;
        }
    }
}
