using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace SMS.UseCases.Pagination.CursorPagination;

public sealed record Cursor(long CreatedAt, Guid LastId)
{
    public static string Encode(long createdAt, Guid lastId)
    {
        var cursor = new Cursor(createdAt, lastId);
        string json = JsonSerializer.Serialize(cursor);
        return Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(json));
    }

    public static Cursor? Decode(string? cursor)
    {
        if (string.IsNullOrWhiteSpace(cursor))
        {
            return null;
        }

        try
        {
            string json = Base64UrlEncoder.Decode(cursor);
            return JsonSerializer.Deserialize<Cursor>(json);
        }
        catch (Exception)
        {
            return null;
        }
    }
}