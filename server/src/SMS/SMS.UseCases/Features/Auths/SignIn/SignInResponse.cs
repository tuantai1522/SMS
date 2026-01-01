using SMS.Core.Features.Users;

namespace SMS.UseCases.Features.Auths.SignIn;

public sealed record SignInResponse(string Token, Guid UserId, string Email, UserStatus Status);
