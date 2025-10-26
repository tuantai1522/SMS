using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Teams.GetTeams;

public sealed record GetTeamsQuery : IRequest<Result<IReadOnlyList<GetTeamsResponse>>>;
