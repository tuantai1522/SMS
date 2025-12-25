namespace SMS.Core.Common;

public class BaseResult
{
    public bool Success { get; init; }
    public List<Error>? Errors { get; init; }

    protected BaseResult(bool success, List<Error>? errors)
    {
        Success = success;
        Errors = errors;
    }

    public static BaseResult SuccessResult() => new(true, null);

    public static BaseResult FailureResult(Error error) => new(false, [error]);

    public static BaseResult FailureResult(IEnumerable<Error> errors) =>
        new(false, errors.ToList());

    public static BaseResult FromResult(Result result) => result.IsSuccess ? SuccessResult() : FailureResult(result.Error);
}

public class BaseResult<T>
{
    public bool Success { get; init; }

    public T? Data { get; init; }

    public List<Error>? Errors { get; init; }

    private BaseResult(bool success, T? data, List<Error>? errors)
    {
        Success = success;
        Data = data;
        Errors = errors;
    }

    public static BaseResult<T> SuccessResult(T? data) => new(true, data, null);

    public static BaseResult<T> FailureResult(Error error) => new(false, default, [error]);

    public static BaseResult<T> FailureResult(IEnumerable<Error> errors) =>new(false, default, [.. errors]);

    public static BaseResult<T> FromResult(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new BaseResult<T>(true, result.Value, null);
        }

        // Validation failed
        if (result.Error is ValidationError validationError)
        {
            return new BaseResult<T>(false, default, validationError.Errors.ToList());
        }

        return new BaseResult<T>(false, default, [result.Error]);

    }

    public static BaseResult<T> FromResult(Result result)
    {
        return result.IsSuccess ? 
            new BaseResult<T>(true, default, null) : 
            new BaseResult<T>(false, default, [result.Error]);
    }
}
