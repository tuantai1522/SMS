namespace SMS.UseCases.Features.Workspaces.GetMembersByWorkspaceId;

public sealed record GetMembersByWorkspaceIdResponse (Guid Id, string GivenName, string Email, Guid RoleId, string RoleName, long JoinedAt);


