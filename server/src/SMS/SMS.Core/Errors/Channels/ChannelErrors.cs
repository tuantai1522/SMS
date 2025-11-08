using SMS.Core.Common;

namespace SMS.Core.Errors.Channels;

public static class ChannelErrors
{
    public static readonly Error CanNotFindChannel = Error.NotFound(
        ChannelErrorCode.CanNotFindChannel,
        "Can not find channel");
}
