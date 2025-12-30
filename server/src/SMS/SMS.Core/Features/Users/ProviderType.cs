using System.Text.Json.Serialization;

namespace SMS.Core.Features.Users;

/// <summary>
/// To store string in database
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProviderType
{
    Facebook = 1,
}