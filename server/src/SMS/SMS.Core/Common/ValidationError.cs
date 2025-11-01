using SMS.Core.Features;

namespace SMS.Core.Common;

public sealed record ValidationError(Error[] Errors) 
    : Error((int)ErrorCode.Validation, "One or more validation errors occurred")
{
    public static ValidationError FromResults(IEnumerable<Result> results) => 
        new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
}