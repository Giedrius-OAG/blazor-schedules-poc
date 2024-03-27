using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class AirlineScheduleContext : DbContext
{
    public AirlineScheduleContext(DbContextOptions<AirlineScheduleContext> options) : base(options)
    {
    }

    public DbSet<AirlineSchedule> AirlineSchedules { get; set; } = null!;
}
