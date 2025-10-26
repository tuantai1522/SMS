using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Channels;
using SMS.UseCases.Abstractions.Authentication;

namespace SMS.UseCases.Features.Channels.GetChannelsByTeamId;

internal sealed class GetChannelsByTeamIdQueryHandler(
    IUserProvider userProvider,
    IChannelRepository channelRepository) : IRequestHandler<GetChannelsByTeamIdQuery, Result<IReadOnlyList<GetChannelsByTeamIdResponse>>>
{
    public async Task<Result<IReadOnlyList<GetChannelsByTeamIdResponse>>> Handle(GetChannelsByTeamIdQuery query, CancellationToken cancellationToken)
    {
        var userId = userProvider.UserId;

        var channels = await channelRepository.GetChannelsByUserIdAndTeamIdAsync(userId, query.TeamId, cancellationToken);

        return channels.Select(channel => new GetChannelsByTeamIdResponse(channel.Id, channel.DisplayName, channel.Description)).ToList();
    }
}
