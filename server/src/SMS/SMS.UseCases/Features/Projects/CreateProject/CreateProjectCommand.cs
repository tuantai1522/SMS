using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Projects.CreateProject;

public sealed record CreateProjectCommand(string Name, string Code, string? Emoji, string? Description, Guid WorkspaceId) : IRequest<Result<Guid>>;
