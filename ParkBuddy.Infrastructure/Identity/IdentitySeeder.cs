using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Infrastructure.Identity;

public class IdentitySeeder
{
    public static async Task SeedRoles(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var roleMangaer = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        foreach (Roles role in Enum.GetValues(typeof(Roles)))
        {
            var roleName = role.ToString();
            if (!await roleMangaer.RoleExistsAsync(roleName))
            {
                await roleMangaer.CreateAsync(new IdentityRole<Guid>(roleName));
            }
        }
    }
}
