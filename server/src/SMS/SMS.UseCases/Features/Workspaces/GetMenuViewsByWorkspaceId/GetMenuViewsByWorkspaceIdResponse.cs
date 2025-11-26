namespace SMS.UseCases.Features.Workspaces.GetMenuViewsByWorkspaceId;

public sealed record GetMenuViewsByWorkspaceIdResponse(Guid Id, string Name, int Code, string? Vid, string? Icon);


