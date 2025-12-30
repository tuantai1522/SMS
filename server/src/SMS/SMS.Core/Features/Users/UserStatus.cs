using System.Text.Json.Serialization;

namespace SMS.Core.Features.Users;

/// <summary>
/// To store string in database
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserStatus
{
    PendingConfirmation = 1,
    OnboardingRequired = 2,
    Active = 3,
    Deleted = 4
}