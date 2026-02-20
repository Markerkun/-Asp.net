using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.Helpers
{
    internal static class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            // отримання AppDbContext із DI
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserModel>>();
            using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            context.Database.Migrate(); // застосовує всі міграції як і команда "update-database"

            if (!roleManager.Roles.Any())
            {
                var adminRole = new IdentityRole { Name = "Admin" };
                var userRole = new IdentityRole{Name = "User"};

                roleManager.CreateAsync(adminRole).Wait();
                roleManager.CreateAsync(userRole).Wait();

                var admin = new UserModel
                {
                    Email = "admin@gmail.com",
                    UserName = "Admin",
                    EmailConfirmed = true,
                    Name = "Jon",
                    Surname = "Doe"
                };
                var user = new UserModel
                {
                    Email = "user@gmail.com",
                    UserName = "User",
                    EmailConfirmed = true,
                    Name = "Ben",
                    Surname = "Smith"
                };
                if (!context.Categories.Any())
            {
                string root = Directory.GetCurrentDirectory();
                string path = Path.Combine(root, "wwwroot", "seed_data", "components.json");
                string json = File.ReadAllText(path);
                List<CategoryModel>? categories = JsonSerializer.Deserialize<List<CategoryModel>>(json);

                if (categories == null)
                {
                    return;
                }

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
        }

    }

}