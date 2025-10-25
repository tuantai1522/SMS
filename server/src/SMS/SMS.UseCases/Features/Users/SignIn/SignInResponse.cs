namespace SMS.UseCases.Features.Users.SignIn;

public sealed record SignInResponse(string Token, Guid UserId, string Email);
