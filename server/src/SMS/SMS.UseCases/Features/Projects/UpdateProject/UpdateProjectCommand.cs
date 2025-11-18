using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Projects.UpdateProject;

public sealed record UpdateProjectCommand(Guid Id, string Name, string Code, string? Emoji, string? Description) : IRequest<Result<Guid>>;
