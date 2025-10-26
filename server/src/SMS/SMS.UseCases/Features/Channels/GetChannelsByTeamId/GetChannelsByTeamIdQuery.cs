using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Channels.GetChannelsByTeamId;

public sealed record GetChannelsByTeamIdQuery(Guid TeamId) : IRequest<Result<IReadOnlyList<GetChannelsByTeamIdResponse>>>;
