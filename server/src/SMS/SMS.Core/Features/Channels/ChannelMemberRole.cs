using System.Text.Json.Serialization;

namespace SMS.Core.Features.Channels;

/// <summary>
/// To store string in database
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ChannelMemberRole
{
    Owner = 1,
    Member = 2
}