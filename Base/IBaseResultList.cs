public interface IBaseResultList<T> : IBaseResult<IReadOnlyList<T>>
{
    int TotalCount { get; }
    int? Page { get; }
    int? PageSize { get; }
}

public class BaseResultList<T> : BaseResult<IReadOnlyList<T>>, IBaseResultList<T>
{
    public int TotalCount { get; }
    public int? Page { get; }
    public int? PageSize { get; }

    protected BaseResultList(bool success, int statusCode, IReadOnlyList<T>? data = null, int? totalCount = null,
        int? page = null, int? pageSize = null, string? errorCode = null, string? errorMessage = null)
        : base(success, statusCode, data, errorCode, errorMessage)
    {
        TotalCount = totalCount ?? data?.Count ?? 0;
        Page = page;
        PageSize = pageSize;
    }

    public BaseResultList(IReadOnlyList<T> data) : this(true, StatusCodes.Status200OK, data) { }

    // Lets methods returning BaseResultList<T> just `return list;`.
    public static implicit operator BaseResultList<T>(List<T> data) => Ok(data);

    public static implicit operator BaseResultList<T>(T[] data) => Ok(data);

    public new static BaseResultList<T> Ok(IReadOnlyList<T> data) => new(true, StatusCodes.Status200OK, data);

    // TotalCount is the number of items across all pages, not just this one.
    public static BaseResultList<T> Paged(IReadOnlyList<T> data, int totalCount, int page, int pageSize)
        => new(true, StatusCodes.Status200OK, data, totalCount, page, pageSize);

    public new static BaseResultList<T> BadRequest(string errorCode, string? errorMessage = null)
        => Fail(StatusCodes.Status400BadRequest, errorCode, errorMessage);

    public new static BaseResultList<T> NotFound(string errorCode, string? errorMessage = null)
        => Fail(StatusCodes.Status404NotFound, errorCode, errorMessage);

    public new static BaseResultList<T> Conflict(string errorCode, string? errorMessage = null)
        => Fail(StatusCodes.Status409Conflict, errorCode, errorMessage);

    public new static BaseResultList<T> Fail(int statusCode, string errorCode, string? errorMessage = null)
        => new(false, statusCode, errorCode: errorCode, errorMessage: errorMessage);

    public override IResult ToHttpResult()
    {
        if (!Success)
            return base.ToHttpResult();

        return Results.Json(new
        {
            Items = Data ?? [],
            TotalCount,
            Page,
            PageSize
        }, statusCode: StatusCode);
    }
}
