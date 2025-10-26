using SMS.Core.Common;

namespace SMS.Core.Features.Channels;

public static class ChannelErrors
{
    public static readonly Error CanNotFindChannel = Error.NotFound(
        "Teams.CanNotFindChannel",
        "Can not find channel");
}
