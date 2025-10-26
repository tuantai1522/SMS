namespace SMS.UseCases.Features.Channels.GetChannelById;

public sealed record GetChannelByIdResponse(Guid Id, string DisplayName, string? Description);
