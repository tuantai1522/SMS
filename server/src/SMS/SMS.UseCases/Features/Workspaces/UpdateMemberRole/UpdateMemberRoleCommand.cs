using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Workspaces.UpdateMemberRole;

public sealed record UpdateMemberRoleCommand(Guid UserId, Guid WorkspaceId, Guid RoleId) : IRequest<Result<bool>>;
