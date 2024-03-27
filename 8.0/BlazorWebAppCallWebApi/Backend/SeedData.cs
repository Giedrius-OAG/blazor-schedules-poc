using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend;

public class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var context = new AirlineScheduleContext(serviceProvider.GetRequiredService<DbContextOptions<AirlineScheduleContext>>());

        if (!context.AirlineSchedules.Any())
        {
            var schedules = BusinessDataGenerator.GenerateRandomSchedules(50);
            context.AirlineSchedules.AddRange(schedules);
            await context.SaveChangesAsync();
        }
    }
}
