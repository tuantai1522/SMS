using SMS.Core.Common;

namespace SMS.Core.Errors.Channels;

public static class ChannelErrors
{
    public static readonly Error CanNotFindChannel = new(
        ChannelErrorCode.CanNotFindChannel,
        "Can not find channel");
}
