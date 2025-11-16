namespace SMS.UseCases.Features.Projects.GetProjectByIdAndWorkspaceId;

public sealed record GetProjectByIdAndWorkspaceIdResponse(Guid Id, string Name, string Code, string? Emoji, string? Description);
