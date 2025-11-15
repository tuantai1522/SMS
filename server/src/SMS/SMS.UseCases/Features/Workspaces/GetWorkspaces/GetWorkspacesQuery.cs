using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Workspaces.GetWorkspaces;

public sealed record GetWorkspacesQuery : IRequest<Result<IReadOnlyList<GetWorkspacesResponse>>>;
