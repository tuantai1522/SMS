using System.Text.Json.Serialization;

namespace SMS.UseCases.Pagination;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaginationOrder
{
    Descending = 1,
    Ascending = 2
}