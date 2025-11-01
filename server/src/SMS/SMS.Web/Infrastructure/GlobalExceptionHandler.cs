using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SMS.Core.Common;

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

        var result = BaseResult<object>.FromResult(new Result(false, new Error("-1", "Server failure", ErrorType.Problem)));
        
        httpContext.Response.StatusCode = 200;

        await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);

        return true;
    }
}