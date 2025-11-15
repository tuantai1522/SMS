using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Workspaces.UpdateWorkspace;

public sealed record UpdateWorkspaceCommand(Guid Id, string Name, string? Description) : IRequest<Result<Guid>>;
