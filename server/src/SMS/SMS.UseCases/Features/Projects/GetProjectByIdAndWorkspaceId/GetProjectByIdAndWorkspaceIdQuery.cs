using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Projects.GetProjectByIdAndWorkspaceId;

public sealed record GetProjectByIdAndWorkspaceIdQuery(Guid Id, Guid WorkspaceId) : IRequest<Result<GetProjectByIdAndWorkspaceIdResponse>>;
