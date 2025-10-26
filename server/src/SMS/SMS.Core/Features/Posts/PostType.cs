using System.Text.Json.Serialization;

namespace SMS.Core.Features.Posts;

/// <summary>
/// To store string in database
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PostType
{
    Normal = 1,
}