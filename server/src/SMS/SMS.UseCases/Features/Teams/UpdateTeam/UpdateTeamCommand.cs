using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Teams.UpdateTeam;

public sealed record UpdateTeamCommand(Guid Id, string DisplayName, string? Description) : IRequest<Result<Guid>>;
