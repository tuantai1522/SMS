namespace SMS.UseCases.Features.Workspaces.GetMembersByWorkspaceId;

public sealed record GetMembersByWorkspaceIdResponse (Guid Id, string FirstName, string? MiddleName, string? LastName, string Email, Guid RoleId, string RoleName, long JoinedAt);


