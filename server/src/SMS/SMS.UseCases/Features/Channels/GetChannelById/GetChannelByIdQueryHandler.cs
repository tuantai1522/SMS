using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Channels;
using SMS.Core.Features.Channels;
using SMS.Core.Features.Teams;
using SMS.UseCases.Features.Teams.GetTeamById;

namespace SMS.UseCases.Features.Channels.GetChannelById;

internal sealed class GetChannelByIdQueryHandler(IChannelRepository channelRepository): IRequestHandler<GetChannelByIdQuery, Result<GetChannelByIdResponse>>
{
    public async Task<Result<GetChannelByIdResponse>> Handle(GetChannelByIdQuery query, CancellationToken cancellationToken)
    {
        var channel = await channelRepository.FindChannelByIdAsync(query.Id, cancellationToken);
        
        return channel is null ? 
            Result.Failure<GetChannelByIdResponse>(ChannelErrors.CanNotFindChannel) : 
            Result.Success(new GetChannelByIdResponse(channel.Id, channel.DisplayName, channel.Description));
    }
}
