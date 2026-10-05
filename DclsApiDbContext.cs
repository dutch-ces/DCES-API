using API.Players;
using Microsoft.EntityFrameworkCore;

public class DclsApiDbContext : DbContext
{
    public DclsApiDbContext(DbContextOptions<DclsApiDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }

    public DbSet<PlayerTeams> PlayerTeams { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<Match> Matches { get; set; }

    public DbSet<PlayerMatch> PlayerMatches { get; set; }

    public DbSet<Series> Series { get; set; }

    public DbSet<Champion> Champions { get; set; }

    public DbSet<Division> Divisions { get; set; }

    public DbSet<Association> Associations { get; set; }
}

