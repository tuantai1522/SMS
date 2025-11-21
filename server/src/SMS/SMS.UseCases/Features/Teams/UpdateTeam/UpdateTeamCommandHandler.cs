using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Teams;
using SMS.Core.Features.Teams;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Teams.UpdateTeam;

internal sealed class UpdateTeamCommandHandler(
    IUnitOfWork unitOfWork,
    ITeamRepository teamRepository): IRequestHandler<UpdateTeamCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(UpdateTeamCommand command, CancellationToken cancellationToken)
    {
        var team = await teamRepository.FindTeamByIdAsync(command.Id, cancellationToken);
        
        if (team is null)
        {
            return Result.Failure<Guid>(TeamErrors.CanNotFindTeam);
        }
            
        team.Update(command.DisplayName, command.Description);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(team.Id);
    }
}
