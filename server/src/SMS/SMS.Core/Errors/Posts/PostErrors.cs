using SMS.Core.Common;
using SMS.Core.Features;

namespace SMS.Core.Errors.Posts;

public static class PostErrors
{
    public static readonly Error InvalidCursorValue = new(
        ErrorCode.InvalidCursorValue,
        "Cursor value is invalid. Please check again!");
    
    public static readonly Error ThisMessageCanNotEditAnymore = new(
        PostErrorCode.ThisMessageCanNotEditAnymore,
        "This message can not edit any more");
    
    public static readonly Error ThisMessageCanNotRecallAnymore = new(
        PostErrorCode.ThisMessageCanNotRecallAnymore,
        "This message can not recall any more");
    
    public static readonly Error DoNotHavePermissionToRecallThisMessage = new(
        PostErrorCode.DoNotHavePermissionToRecallThisMessage,
        "You don't have permission to recall this message");
    
    public static readonly Error DoNotHavePermissionToEditThisMessage = new(
        PostErrorCode.DoNotHavePermissionToEditThisMessage,
        "You don't have permission to edit this message");
    
    public static readonly Error CanNotFindPost = new(
        PostErrorCode.CanNotFindPost,
        "Can't not find post");
}
