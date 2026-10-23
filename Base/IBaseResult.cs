public interface IBaseResult<T> : IResult
{
    bool Success { get; }
    int StatusCode { get; }
    string? ErrorCode { get; }
    string? ErrorMessage { get; }
    T? Data { get; }

    IResult ToHttpResult();
}

public class BaseResult<T> : IBaseResult<T>
{
    public bool Success { get; }
    public int StatusCode { get; }
    public string? ErrorCode { get; }
    public string? ErrorMessage { get; }
    public T? Data { get; }

    protected BaseResult(bool success, int statusCode, T? data = default, string? errorCode = null, string? errorMessage = null)
    {
        Success = success;
        StatusCode = statusCode;
        Data = data;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public BaseResult(T data) : this(true, StatusCodes.Status200OK, data) { }

    // Lets methods returning BaseResult<T> just `return data;`.
    public static implicit operator BaseResult<T>(T data) => Ok(data);

    public static BaseResult<T> Ok(T data) => new(true, StatusCodes.Status200OK, data);

    public static BaseResult<T> Created(T data) => new(true, StatusCodes.Status201Created, data);

    public static BaseResult<T> NoContent() => new(true, StatusCodes.Status204NoContent);

    public static BaseResult<T> BadRequest(string errorCode, string? errorMessage = null)
        => Fail(StatusCodes.Status400BadRequest, errorCode, errorMessage);

    public static BaseResult<T> NotFound(string errorCode, string? errorMessage = null)
        => Fail(StatusCodes.Status404NotFound, errorCode, errorMessage);

    public static BaseResult<T> Conflict(string errorCode, string? errorMessage = null)
        => Fail(StatusCodes.Status409Conflict, errorCode, errorMessage);

    public static BaseResult<T> Fail(int statusCode, string errorCode, string? errorMessage = null)
        => new(false, statusCode, errorCode: errorCode, errorMessage: errorMessage);

    public virtual IResult ToHttpResult()
    {
        if (!Success)
            return Results.Problem(
                detail: ErrorMessage,
                statusCode: StatusCode,
                title: ErrorCode,
                extensions: new Dictionary<string, object?> { ["errorCode"] = ErrorCode });

        return StatusCode switch
        {
            StatusCodes.Status204NoContent => Results.NoContent(),
            _ => Results.Json(Data, statusCode: StatusCode)
        };
    }

    // Lets endpoints return a BaseResult directly.
    public Task ExecuteAsync(HttpContext httpContext) => ToHttpResult().ExecuteAsync(httpContext);
}
