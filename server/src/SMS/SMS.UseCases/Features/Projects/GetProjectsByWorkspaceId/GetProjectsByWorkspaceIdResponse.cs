namespace SMS.UseCases.Features.Projects.GetProjectsByWorkspaceId;

public sealed record GetProjectsByWorkspaceIdResponse(Guid Id, string Name, string? Emoji);
