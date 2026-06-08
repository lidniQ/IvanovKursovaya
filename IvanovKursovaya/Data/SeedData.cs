using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IvanovKursovaya.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var contextFactory = serviceProvider.GetRequiredService<IDbContextFactory<TicketContext>>();
        await using var context = await contextFactory.CreateDbContextAsync();

        await context.Database.MigrateAsync();

        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // Создаём роли
        foreach (var role in new[] { "Administrator", "User" })
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // Создаём города
        if (!await context.Cities.AnyAsync())
        {
            context.Cities.AddRange(
                new City { CityName = "Москва" },
                new City { CityName = "Санкт-Петербург" },
                new City { CityName = "Казань" }
            );
            await context.SaveChangesAsync();
        }

        // Создаём маршруты
        if (!await context.Routes.AnyAsync())
        {
            context.Routes.AddRange(
                new Route { FromCity = "Москва", ToCity = "Санкт-Петербург", DistanceKm = 700 },
                new Route { FromCity = "Москва", ToCity = "Казань", DistanceKm = 820 },
                new Route { FromCity = "Санкт-Петербург", ToCity = "Казань", DistanceKm = 1500 }
            );
            await context.SaveChangesAsync();
        }

        // Создаём расписания
        if (!await context.Schedules.AnyAsync())
        {
            var routes = await context.Routes.ToListAsync();
            context.Schedules.AddRange(
                new Schedule
                {
                    RouteId = routes[0].RouteId,
                    DepartureDate = DateTime.Today.AddDays(1),
                    DepartureTime = new TimeSpan(8, 0, 0),
                    ArrivalTime = new TimeSpan(16, 30, 0),
                    Carrier = "АвтоЭкспресс",
                    TotalSeats = 40,
                    Price = 1200m
                },
                new Schedule
                {
                    RouteId = routes[1].RouteId,
                    DepartureDate = DateTime.Today.AddDays(2),
                    DepartureTime = new TimeSpan(9, 0, 0),
                    ArrivalTime = new TimeSpan(19, 0, 0),
                    Carrier = "ВолгаТранс",
                    TotalSeats = 35,
                    Price = 1500m
                },
                new Schedule
                {
                    RouteId = routes[2].RouteId,
                    DepartureDate = DateTime.Today.AddDays(3),
                    DepartureTime = new TimeSpan(7, 0, 0),
                    ArrivalTime = new TimeSpan(23, 30, 0),
                    Carrier = "СеверЭкспресс",
                    TotalSeats = 50,
                    Price = 2500m
                }
            );
            await context.SaveChangesAsync();
        }

        // Создаём admin-пользователя
        const string adminEmail = "admin@tickets.ru";
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var city = await context.Cities.FirstOrDefaultAsync();
            var admin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                Surname = "Администратор",
                Ima = "Главный",
                SecSurname = "Системный",
                CityId = city?.CityId
            };
            var result = await userManager.CreateAsync(admin, "Admin123!");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, "Administrator");
        }
    }
}
