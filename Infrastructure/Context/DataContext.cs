namespace Infrastructure.Context;

using Microsoft.EntityFrameworkCore;


public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) :base(options)
    {
        
    }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Challenge> Challenges { get; set; }
}
