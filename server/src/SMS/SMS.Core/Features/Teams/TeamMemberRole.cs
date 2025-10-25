using System.Text.Json.Serialization;

namespace SMS.Core.Features.Teams;

/// <summary>
/// To store string in database
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TeamMemberRole
{
    Owner = 1,
    Member = 2
}