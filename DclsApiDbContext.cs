using API.Players;
using Microsoft.EntityFrameworkCore;

public class DclsApiDbContext : DbContext
{
    public DclsApiDbContext(DbContextOptions<DclsApiDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerTeams> PlayerTeams { get; set; }
}

