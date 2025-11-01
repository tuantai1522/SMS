namespace SMS.Core.Common;

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

    public static BaseResult<T> FromResult(Result<T> result)
    {
        return result.IsSuccess ? 
            new BaseResult<T>(true, result.Value, null) : 
            new BaseResult<T>(false, default, [result.Error]);
    }

    public static BaseResult<T> FromResult(Result result)
    {
        return result.IsSuccess ? 
            new BaseResult<T>(true, default, null) : 
            new BaseResult<T>(false, default, [result.Error]);
    }
}
