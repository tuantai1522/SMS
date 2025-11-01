using SMS.Core.Common;
using SMS.Core.Features;

namespace SMS.Core.Errors.Posts;

public static class PostErrors
{
    public static readonly Error InvalidCursorValue = new(
        ErrorCode.InvalidCursorValue,
        "Cursor value is invalid. Please check again!");
}
