namespace SMS.UseCases.Features.Teams.GetTeamById;

public sealed record GetTeamByIdResponse(Guid Id, string DisplayName, string? Description);
