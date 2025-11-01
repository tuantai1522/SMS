using SMS.Core.Common;

namespace SMS.Core.Features.Posts;

public static class PostErrors
{
    public static readonly Error InvalidCursorValue = Error.NotFound(
        "Teams.InvalidCursorValue",
        "Cursor value is invalid. Please check again!");
}
