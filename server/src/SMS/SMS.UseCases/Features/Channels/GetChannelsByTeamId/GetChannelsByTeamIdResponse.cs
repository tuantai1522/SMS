namespace SMS.UseCases.Features.Channels.GetChannelsByTeamId;

public sealed record GetChannelsByTeamIdResponse(Guid Id, string DisplayName, string? Description);
