namespace SMS.Core.Common;

public enum ErrorType
{
    Validation = 0, // 400: Bad request
    NotFound = 1, // 404: Not found
    Conflict = 2, // 409: Conflict
    Server = 4, // 500: Server error
    Failure = 5 // Don't have error
}