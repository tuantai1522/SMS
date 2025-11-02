namespace SMS.Core.Errors.Posts;

public static class PostErrorCode
{
    public const int ThisMessageCanNotEditAnymore = -5000;
    public const int ThisMessageCanNotRecallAnymore = -5001;
    public const int DoNotHavePermissionToRecallThisMessage = -5002;
    public const int DoNotHavePermissionToEditThisMessage = -5003;
    public const int PostIdCanNotBeEmpty = -5004;
    public const int CanNotFindPost = -5005;
    public const int MessageCanNotBeEmpty = -5006;
}
