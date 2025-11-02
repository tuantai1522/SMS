using Microsoft.AspNetCore.Diagnostics;
using SMS.Core.Common;
using SMS.Core.Features;

namespace SMS.Web.Infrastructure;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled exception occurred");

        var result = BaseResult<object>.FromResult(new Result(false, new Error(ErrorCode.ServerFailure, "Server failure")));
        
        httpContext.Response.StatusCode = 200;

        await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);

        return true;
    }
}