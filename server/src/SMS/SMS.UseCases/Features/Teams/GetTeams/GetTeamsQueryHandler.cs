using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Teams;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.UseCases.Features.Teams.GetTeams;

internal sealed class GetTeamByIdQueryHandler(
    IUserProvider  userProvider,
    ITeamRepository teamRepository): IRequestHandler<GetTeamsQuery, Result<IReadOnlyList<GetTeamsResponse>>>
{
    public async Task<Result<IReadOnlyList<GetTeamsResponse>>> Handle(GetTeamsQuery query, CancellationToken cancellationToken)
    {
        var userId = userProvider.UserId;
        
        var teams = await teamRepository.GetTeamsByUserIdAsync(userId, cancellationToken);
        
        return teams.Select(team => new GetTeamsResponse(team.Id, team.DisplayName, team.Description)).ToList();
    }
}
