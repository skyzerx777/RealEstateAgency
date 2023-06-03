using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace RealEstateAgency.Data
{
    public static class DataSeeder
    {
        public static async Task SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Создание роли "master", если ее еще нет
            if (!await roleManager.RoleExistsAsync("master"))
            {
                await roleManager.CreateAsync(new IdentityRole("master"));
            }
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            // Создание пользователей
            await CreateUserAsync(userManager, "admin1", "Qwerty1!", "master");
            await CreateUserAsync(userManager, "admin2", "Qwerty1!", "admin");
        }

        private static async Task CreateUserAsync(UserManager<IdentityUser> userManager, string username, string password, string role = "admin")
        {
            var user = new IdentityUser { UserName = username };
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded && !string.IsNullOrEmpty(role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
