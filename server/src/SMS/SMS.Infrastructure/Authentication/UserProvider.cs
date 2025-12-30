using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.Infrastructure.Authentication;

public sealed class UserProvider(IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : IUserProvider
{
    public Guid UserId =>
        httpContextAccessor
            .HttpContext?
            .User
            .GetUserId() ??
        Guid.Empty;

    public (string verificationToken, long expiredAt) GenerateTokenAndExpiredAtForUserSignedUp()
    {
        var token = Guid.NewGuid().ToString();
        var expiredAt = DateTimeOffset.UtcNow.AddSeconds(configuration.GetValue<long>("ApplicationOptions:ExpiredEmailVerificationToken")).ToUnixTimeMilliseconds();
        
        return (token, expiredAt);
    }
}