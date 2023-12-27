using DB;
using Microsoft.EntityFrameworkCore;

public class ElevatorDbContext : DbContext
{
    public DbSet<ElevatorStatus> ElevatorStates { get; set; }
    public DbSet<ElevatorRequest> ElevatorRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ElevatorDatabase");
    }
}
