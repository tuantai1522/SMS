using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Workspaces.GetRoles;

public sealed record GetRolesQuery : IRequest<Result<IReadOnlyList<GetRolesResponse>>>;
