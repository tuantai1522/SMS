using SMS.Core.Common;
using SMS.Core.Features;

namespace SMS.Core.Errors.Posts;

public static class PostErrors
{
    public static readonly Error InvalidCursorValue = Error.Validation(
        ErrorCode.InvalidCursorValue,
        "Cursor value is invalid. Please check again!");
    
    public static readonly Error ThisMessageCanNotEditAnymore = Error.Validation(
        PostErrorCode.ThisMessageCanNotEditAnymore,
        "This message can not edit any more");
    
    public static readonly Error ThisMessageCanNotRecallAnymore = Error.Validation(
        PostErrorCode.ThisMessageCanNotRecallAnymore,
        "This message can not recall any more");
    
    public static readonly Error DoNotHavePermissionToRecallThisMessage = Error.Validation(
        PostErrorCode.DoNotHavePermissionToRecallThisMessage,
        "You don't have permission to recall this message");
    
    public static readonly Error DoNotHavePermissionToEditThisMessage = Error.Validation(
        PostErrorCode.DoNotHavePermissionToEditThisMessage,
        "You don't have permission to edit this message");
    
    public static readonly Error CanNotFindPost = Error.Validation(
        PostErrorCode.CanNotFindPost,
        "Can't not find post");
}
