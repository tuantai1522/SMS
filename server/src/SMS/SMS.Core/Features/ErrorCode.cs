namespace SMS.Core.Features;

public static class ErrorCode
{
    public const int None = 0;
    public const int NullValue = -1;
    public const int Validation = -2;
    public const int InvalidCursorValue = -3;
    public const int ServerFailure = -4;
}