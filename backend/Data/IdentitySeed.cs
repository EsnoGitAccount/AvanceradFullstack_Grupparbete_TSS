using Backend.Model;
using Microsoft.AspNetCore.Identity;

namespace Backend.Data
{
    public static class IdentitySeed
    {
        private const string UserRole = "User";
        private const string AdminRole = "Admin";

        public static async Task SeedAsync(IServiceProvider services, IConfiguration configuration)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();

            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

            await EnsureRoleExistsAsync(roleManager, UserRole);
            await EnsureRoleExistsAsync(roleManager, AdminRole);

            await EnsureUserExistsAsync(
                userManager,
                configuration,
                configurationName: "User1",
                roleName: UserRole);

            await EnsureUserExistsAsync(
                userManager,
                configuration,
                configurationName: "User2",
                roleName: UserRole);

            await EnsureUserExistsAsync(
                userManager,
                configuration,
                configurationName: "Admin",
                roleName: AdminRole);
        }

        private static async Task EnsureRoleExistsAsync(RoleManager<IdentityRole<int>> roleManager, string roleName)
        {
            if (await roleManager.RoleExistsAsync(roleName))
            {
                return;
            }

            var result = await roleManager.CreateAsync(new IdentityRole<int>(roleName));

            EnsureSucceeded(result, $"Creating the '{roleName}' role");
        }

        private static async Task EnsureUserExistsAsync(UserManager<User> userManager, IConfiguration configuration, string configurationName, string roleName)
        {
            var configurationPath = $"SeedUsers:{configurationName}";

            var username = GetRequiredConfiguration(configuration, $"{configurationPath}:Username");

            var email = GetRequiredConfiguration(configuration, $"{configurationPath}:Email");

            var password = GetRequiredConfiguration(configuration, $"{configurationPath}:Password");

            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new User
                {
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true
                };

                var createResult = await userManager.CreateAsync(user, password);

                EnsureSucceeded(createResult, $"Creating development user '{configurationName}'");
            }

            if (!await userManager.IsInRoleAsync(user, roleName))
            {
                var roleResult = await userManager.AddToRoleAsync(user, roleName);

                EnsureSucceeded(roleResult, $"Adding development user '{configurationName}' " + $"to the '{roleName}' role");
            }
        }

        private static string GetRequiredConfiguration(IConfiguration configuration, string key)
        {
            var value = configuration[key];

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException($"Required development seed configuration " + $"'{key}' is missing.");
            }

            return value;
        }

        private static void EnsureSucceeded(IdentityResult result, string operation)
        {
            if (result.Succeeded)
            {
                return;
            }

            var errors = string.Join("; ", result.Errors.Select(error => $"{error.Code}: {error.Description}"));

            throw new InvalidOperationException($"{operation} failed: {errors}");
        }
    }
}