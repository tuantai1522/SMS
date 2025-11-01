namespace SMS.Core.Errors.Users;

public static class UserErrorCode
{
    public const int EmailNotUnique = -5000;
    public const int NickNameNotUnique = -5001;
    public const int InvalidPassword = -5002;
    public const int InvalidUserIds = -5003;
    public const int FirstNameEmpty = -5004;
    public const int EmailEmpty = -5005;
    public const int PasswordEmpty = -5006;
    public const int NickNameEmpty = -5007;
    public const int InvalidGenderType = -5008;
    public const int AddressStreetEmpty = -5009;
    public const int CityIdEmpty = -5009;
}
