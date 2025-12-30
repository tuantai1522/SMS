namespace SMS.UseCases.Abstractions.Authentication;

public interface IUserProvider
{
    /// <summary>
    /// Get UserId from Jwt token.
    /// </summary>
    Guid UserId { get; }


    /// <summary>
    /// Generate token and expiredAt for user signed up.
    /// </summary>
    /// <returns></returns>
    (string verificationToken, long expiredAt) GenerateTokenAndExpiredAtForUserSignedUp();
}