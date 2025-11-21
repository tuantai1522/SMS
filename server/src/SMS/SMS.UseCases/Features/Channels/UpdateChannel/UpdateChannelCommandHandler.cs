using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Channels;
using SMS.Core.Features.Channels;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Channels.UpdateChannel;

internal sealed class UpdateChannelCommandHandler(
    IUnitOfWork unitOfWork,
    IChannelRepository channelRepository): IRequestHandler<UpdateChannelCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(UpdateChannelCommand command, CancellationToken cancellationToken)
    {
        var channel = await channelRepository.FindChannelByIdAsync(command.Id, cancellationToken);
        
        if (channel is null)
        {
            return Result.Failure<Guid>(ChannelErrors.CanNotFindChannel);
        }
            
        channel.Update(command.DisplayName, command.Description);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(channel.Id);
    }
}
