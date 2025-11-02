namespace SMS.UseCases.Features.Users.GetMe;

public sealed record GetMeResponse(Guid Id, string NickName, string Email);
