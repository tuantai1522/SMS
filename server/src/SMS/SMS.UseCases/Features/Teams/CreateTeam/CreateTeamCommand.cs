using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Teams.CreateTeam;

public sealed record CreateTeamCommand(
    string DisplayName, 
    string? Description,
    IReadOnlyList<Guid> OwnerIds,
    IReadOnlyList<Guid> MemberIds) : IRequest<Result<Guid>>;
