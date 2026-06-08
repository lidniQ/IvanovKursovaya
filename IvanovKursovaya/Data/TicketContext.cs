using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IvanovKursovaya.Data;

public class TicketContext(DbContextOptions<TicketContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}
