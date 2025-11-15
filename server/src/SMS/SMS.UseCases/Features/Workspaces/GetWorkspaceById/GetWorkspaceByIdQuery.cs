using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Workspaces.GetWorkspaceById;

public sealed record GetWorkspaceByIdQuery(Guid Id) : IRequest<Result<GetWorkspaceByIdResponse>>;
