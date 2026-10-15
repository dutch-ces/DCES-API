using System.Linq.Expressions;
using API.Base;
using API.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Hide soft-deleted rows from every query on IDeletable entities.
        // Use .IgnoreQueryFilters() on a query to include them.
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(IDeletable).IsAssignableFrom(entityType.ClrType))
                continue;

            var parameter = Expression.Parameter(entityType.ClrType, "e");
            var filter = Expression.Lambda(
                Expression.Not(Expression.Property(parameter, nameof(IDeletable.IsDeleted))),
                parameter);

            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
        }
    }

    public override EntityEntry Remove(object entity)
    {
        if (entity is IDeletable deletable && Entry(entity).State != EntityState.Added)
        {
            SoftDelete(deletable);
            return Entry(entity);
        }

        return base.Remove(entity);
    }

    public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
    {
        if (entity is not IDeletable deletable || Entry(entity).State == EntityState.Added) return base.Remove(entity);
        SoftDelete(deletable);
        return Entry(entity);

    }

    public override void RemoveRange(params object[] entities) => RemoveRange((IEnumerable<object>)entities);

    public override void RemoveRange(IEnumerable<object> entities)
    {
        foreach (var entity in entities)
            Remove(entity);
    }

    private void SoftDelete(IDeletable entity)
    {
        var entry = Entry((object)entity);
        if (entry.State == EntityState.Detached)
            entry = Attach((object)entity);

        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;
        entry.Property(nameof(IDeletable.IsDeleted)).IsModified = true;
        entry.Property(nameof(IDeletable.DeletedAt)).IsModified = true;
    }

    // Safety net for deletes that bypass the Remove overrides above (e.g. DbSet.Remove).
    // The other SaveChanges overloads call these two, so overriding them is enough.
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ApplySoftDeletes();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ApplySoftDeletes();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void ApplySoftDeletes()
    {
        foreach (var entry in ChangeTracker.Entries<IDeletable>())
        {
            if (entry.State != EntityState.Deleted)
                continue;

            entry.State = EntityState.Modified;
            entry.Entity.IsDeleted = true;
            entry.Entity.DeletedAt = DateTime.UtcNow;
        }
    }
}
