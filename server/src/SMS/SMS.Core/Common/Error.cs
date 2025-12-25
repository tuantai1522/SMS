using SMS.Core.Features;

namespace SMS.Core.Common;

public record Error(int Code, string Description, ErrorType ErrorType)
{
    public static readonly Error None = new(ErrorCode.None, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new(ErrorCode.NullValue, "Null value was provided", ErrorType.Failure);
    
    public static Error Validation(int code, string description) =>
        new(code, description, ErrorType.Validation);

    public static Error NotFound(int code, string description) =>
        new(code, description, ErrorType.NotFound);

    public static Error Conflict(int code, string description) =>
        new(code, description, ErrorType.Conflict);
    
    public static Error Server(int code, string description) =>
        new(code, description, ErrorType.Server);

    public static Error Authorization(int code, string description) =>
        new(code, description, ErrorType.Authorization);

    public static Error Authentication(int code, string description) =>
        new(code, description, ErrorType.Authentication);
}