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

        // Создаём остановки маршрутов
        if (!await context.RouteStops.AnyAsync())
        {
            var routes = await context.Routes.ToListAsync();
            if (routes.Count >= 1)
            {
                context.RouteStops.AddRange(
                    new RouteStop { RouteId = routes[0].RouteId, StopNumber = 1, StationName = routes[0].FromCity, Region = "Россия", TravelTime = "--", DistanceKm = null },
                    new RouteStop { RouteId = routes[0].RouteId, StopNumber = 2, StationName = "Тверь", Region = "Тверская область, Россия", TravelTime = "02:00", DistanceKm = 167 },
                    new RouteStop { RouteId = routes[0].RouteId, StopNumber = 3, StationName = "Вышний Волочёк", Region = "Тверская область, Россия", TravelTime = "03:30", DistanceKm = 294 },
                    new RouteStop { RouteId = routes[0].RouteId, StopNumber = 4, StationName = "Новгород", Region = "Новгородская область, Россия", TravelTime = "05:00", DistanceKm = 450 },
                    new RouteStop { RouteId = routes[0].RouteId, StopNumber = 5, StationName = routes[0].ToCity, Region = "Россия", TravelTime = "08:30", DistanceKm = 700 }
                );
            }
            if (routes.Count >= 2)
            {
                context.RouteStops.AddRange(
                    new RouteStop { RouteId = routes[1].RouteId, StopNumber = 1, StationName = routes[1].FromCity, Region = "Россия", TravelTime = "--", DistanceKm = null },
                    new RouteStop { RouteId = routes[1].RouteId, StopNumber = 2, StationName = "Владимир", Region = "Владимирская область, Россия", TravelTime = "02:30", DistanceKm = 190 },
                    new RouteStop { RouteId = routes[1].RouteId, StopNumber = 3, StationName = "Нижний Новгород", Region = "Нижегородская область, Россия", TravelTime = "05:00", DistanceKm = 410 },
                    new RouteStop { RouteId = routes[1].RouteId, StopNumber = 4, StationName = "Чебоксары", Region = "Чувашская Республика, Россия", TravelTime = "07:30", DistanceKm = 620 },
                    new RouteStop { RouteId = routes[1].RouteId, StopNumber = 5, StationName = routes[1].ToCity, Region = "Россия", TravelTime = "10:00", DistanceKm = 820 }
                );
            }
            if (routes.Count >= 3)
            {
                context.RouteStops.AddRange(
                    new RouteStop { RouteId = routes[2].RouteId, StopNumber = 1, StationName = routes[2].FromCity, Region = "Россия", TravelTime = "--", DistanceKm = null },
                    new RouteStop { RouteId = routes[2].RouteId, StopNumber = 2, StationName = "Петрозаводск", Region = "Карелия, Россия", TravelTime = "03:00", DistanceKm = 280 },
                    new RouteStop { RouteId = routes[2].RouteId, StopNumber = 3, StationName = "Москва", Region = "Россия", TravelTime = "08:00", DistanceKm = 700 },
                    new RouteStop { RouteId = routes[2].RouteId, StopNumber = 4, StationName = "Нижний Новгород", Region = "Нижегородская область, Россия", TravelTime = "12:00", DistanceKm = 1100 },
                    new RouteStop { RouteId = routes[2].RouteId, StopNumber = 5, StationName = routes[2].ToCity, Region = "Россия", TravelTime = "16:30", DistanceKm = 1500 }
                );
            }
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
