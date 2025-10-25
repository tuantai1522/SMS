using Microsoft.AspNetCore.Http;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.Infrastructure.Authentication;

public sealed class UserProvider(IHttpContextAccessor httpContextAccessor) : IUserProvider
{
    public Guid UserId =>
        httpContextAccessor
            .HttpContext?
            .User
            .GetUserId() ??
        Guid.Empty;
}