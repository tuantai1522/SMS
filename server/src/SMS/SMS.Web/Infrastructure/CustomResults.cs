using SMS.Core.Common;

namespace SMS.Web.Infrastructure;

public static class CustomResults
{
    public static IResult Ok<T>(T value) => Results.Ok(BaseResult<T>.FromResult(value));

    public static IResult Problem<T>(Result<T> result)
    {
        var baseResult = BaseResult<T>.FromResult(result);

        if (baseResult.Errors?.Any(e => e.ErrorType == ErrorType.Validation) == true)
        {
            return Results.BadRequest(baseResult);
        }

        if (baseResult.Errors?.Any(e => e.ErrorType == ErrorType.NotFound) == true)
        {
            return Results.NotFound(baseResult);
        }
        
        if (baseResult.Errors?.Any(e => e.ErrorType == ErrorType.Conflict) == true)
        {
            return Results.Conflict(baseResult);
        }

        // Return 500 error
        return Results.Problem();
    }
}