namespace SMS.UseCases.Features.Teams.GetTeams;

public sealed record GetTeamsResponse(Guid Id, string DisplayName, string? Description);
