using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Teams;
using SMS.Core.Errors.Users;
using SMS.Core.Features.Channels;
using SMS.Core.Features.Teams;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Channels.CreateChannel;

internal sealed class CreateChannelCommandHandler(
    IUserProvider userProvider,
    IUnitOfWork unitOfWork,
    ITeamRepository teamRepository,
    IUserRepository userRepository,
    IChannelRepository channelRepository): IRequestHandler<CreateChannelCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateChannelCommand command, CancellationToken cancellationToken)
    {
        var verifyExistedTeam = await teamRepository.VerifyExistedTeamByIdAsync(command.TeamId, cancellationToken);

        if (!verifyExistedTeam)
        {
            return Result.Failure<Guid>(TeamErrors.CanNotFindTeam);
        }
        
        var totalUserIds = command.OwnerIds.Concat(command.MemberIds).ToList();
        
        var verifyExistedUserIds = await userRepository.VerifyExistedUserIdsAsync(totalUserIds, cancellationToken);

        if (!verifyExistedUserIds)
        {
            return Result.Failure<Guid>(UserErrors.InvalidUserIds);
        }

        var totalOwnerIds = command.OwnerIds.Concat([userProvider.UserId]).ToList();
        
        var channel = Channel.CreateChannel(command.DisplayName, command.Description, command.TeamId, totalOwnerIds, command.MemberIds);
        
        await channelRepository.AddChannelAsync(channel, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(channel.Id);
    }
}
