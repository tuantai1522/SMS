using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Users;
using SMS.Core.Features.Teams;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.UseCases.Features.Teams.CreateTeam;

internal sealed class CreateTeamCommandHandler(
    IUserProvider userProvider,
    IUnitOfWork unitOfWork,
    ITeamRepository teamRepository,
    IUserRepository userRepository): IRequestHandler<CreateTeamCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateTeamCommand command, CancellationToken cancellationToken)
    {
        var totalUserIds = command.OwnerIds.Concat(command.MemberIds).ToList();
        
        var verifyExistedUserIds = await userRepository.VerifyExistedUserIdsAsync(totalUserIds, cancellationToken);

        if (!verifyExistedUserIds)
        {
            return Result.Failure<Guid>(UserErrors.InvalidUserIds);
        }

        var totalOwnerIds = command.OwnerIds.Concat([userProvider.UserId]).ToList();
        
        var team = Team.CreateTeam(command.DisplayName, command.Description, totalOwnerIds, command.MemberIds);
        
        await teamRepository.AddTeamAsync(team, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(team.Id);
    }
}
