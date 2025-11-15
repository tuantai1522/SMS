using SMS.Core.Common;

namespace SMS.Core.Features.Workspaces;

public sealed record WorkspaceCreatedDomainEvent(Guid WorkspaceId, Guid UserId) : IDomainEvent;
