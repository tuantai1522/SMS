using SMS.Core.Features.Users;

namespace SMS.UseCases.Features.Auths.GoogleSignIn.GoogleSignIn;

public sealed record GoogleSignInResponse(string Token, Guid UserId, string Email, UserStatus Status);
