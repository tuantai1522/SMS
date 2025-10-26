using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Teams.GetTeamById;

public sealed record GetTeamByIdQuery(Guid Id) : IRequest<Result<GetTeamByIdResponse>>;
