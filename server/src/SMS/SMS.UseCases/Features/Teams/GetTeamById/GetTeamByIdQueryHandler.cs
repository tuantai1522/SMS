using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Teams;

namespace SMS.UseCases.Features.Teams.GetTeamById;

internal sealed class GetTeamByIdQueryHandler(ITeamRepository teamRepository): IRequestHandler<GetTeamByIdQuery, Result<GetTeamByIdResponse>>
{
    public async Task<Result<GetTeamByIdResponse>> Handle(GetTeamByIdQuery command, CancellationToken cancellationToken)
    {
        var team = await teamRepository.FindTeamByIdAsync(command.Id, cancellationToken);
        
        return team is null ? 
            Result.Failure<GetTeamByIdResponse>(TeamErrors.CanNotFindTeam) : 
            Result.Success(new GetTeamByIdResponse(team.Id, team.DisplayName, team.Description));
    }
}
