using Microsoft.EntityFrameworkCore;

public class DclsApiDbContext : DbContext
{
    public DclsApiDbContext(DbContextOptions<DclsApiDbContext> options) : base(options)
    {
    }

    
}

