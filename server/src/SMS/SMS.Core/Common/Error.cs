using SMS.Core.Features;

namespace SMS.Core.Common;

public record Error(int Code, string Description)
{
    public static readonly Error None = new((int)ErrorCode.None, string.Empty);
    public static readonly Error NullValue = new((int)ErrorCode.NullValue, "Null value was provided");
}