using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Workspaces.CreateWorkspace;

public sealed record CreateWorkspaceCommand(string Name, string? Description) : IRequest<Result<Guid>>;
