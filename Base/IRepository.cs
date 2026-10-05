using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public interface IRepository<T> where T : class
{
    IQueryable<T> Query(bool track = true);
    Task<T?> GetByIdAsync(object id, CancellationToken ct = default);
    Task<List<T>> GetAllAsync(bool track = true, CancellationToken ct = default);
    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, bool track = true, CancellationToken ct = default);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool track = true, CancellationToken ct = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default);
    Task AddAsync(T entity, CancellationToken ct = default);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    Task<int> SaveChangesAsync(CancellationToken ct = default);

    T? GetById(object id);
    List<T> GetAll(bool track = true);
    List<T> Find(Expression<Func<T, bool>> predicate, bool track = true);
    T? FirstOrDefault(Expression<Func<T, bool>> predicate, bool track = true);
    bool Any(Expression<Func<T, bool>> predicate);
    int Count(Expression<Func<T, bool>>? predicate = null);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    int SaveChanges();
}

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext Context;
    protected readonly DbSet<T> Set;

    public Repository(DbContext context)
    {
        Context = context;
        Set = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(object id, CancellationToken ct = default)
        => await Set.FindAsync(new[] { id }, ct);

    public virtual IQueryable<T> Query(bool track = true) => track ? Set : Set.AsNoTracking();

    public virtual Task<List<T>> GetAllAsync(bool track = true, CancellationToken ct = default)
        => Query(track).ToListAsync(ct);

    public virtual Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, bool track = true, CancellationToken ct = default)
        => Query(track).Where(predicate).ToListAsync(ct);

    public virtual Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool track = true, CancellationToken ct = default)
        => Query(track).FirstOrDefaultAsync(predicate, ct);

    public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        => Set.AnyAsync(predicate, ct);

    public virtual Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default)
        => predicate is null ? Set.CountAsync(ct) : Set.CountAsync(predicate, ct);

    public virtual async Task AddAsync(T entity, CancellationToken ct = default)
        => await Set.AddAsync(entity, ct);

    public virtual Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
        => Set.AddRangeAsync(entities, ct);

    public virtual void Update(T entity) => Set.Update(entity);

    public virtual void Remove(T entity) => Set.Remove(entity);

    public virtual void RemoveRange(IEnumerable<T> entities) => Set.RemoveRange(entities);

    public virtual Task<int> SaveChangesAsync(CancellationToken ct = default)
        => Context.SaveChangesAsync(ct);

    public virtual T? GetById(object id) => Set.Find(id);

    public virtual List<T> GetAll(bool track = true) => Query(track).ToList();

    public virtual List<T> Find(Expression<Func<T, bool>> predicate, bool track = true)
        => Query(track).Where(predicate).ToList();

    public virtual T? FirstOrDefault(Expression<Func<T, bool>> predicate, bool track = true)
        => Query(track).FirstOrDefault(predicate);

    public virtual bool Any(Expression<Func<T, bool>> predicate) => Set.Any(predicate);

    public virtual int Count(Expression<Func<T, bool>>? predicate = null)
        => predicate is null ? Set.Count() : Set.Count(predicate);

    public virtual void Add(T entity) => Set.Add(entity);

    public virtual void AddRange(IEnumerable<T> entities) => Set.AddRange(entities);

    public virtual int SaveChanges() => Context.SaveChanges();
}