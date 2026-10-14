
using Azure.Storage.Blobs;
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

            builder.Services.AddDbContext<WhereAreWeDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddOptions<BlobStorageOptions>()
				.BindConfiguration("AzureBlobStorage");

			builder.Services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<WhereAreWeDbContext>()
                .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddSingleton<IBlobStorageService, BlobStorageService>();
            builder.Services.AddControllers();
            builder.Services.AddProblemDetails();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
                app.MapGet("/", () => Results.Redirect("/scalar"));
            }

            app.UseHttpsRedirection();

            app.UseCors("LocalConnection");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
