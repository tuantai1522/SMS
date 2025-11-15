namespace SMS.UseCases.Features.Workspaces.GetWorkspaceById;

public sealed record GetWorkspaceByIdResponse (Guid Id, string Name, string? Description);


