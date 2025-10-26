using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Channels.GetChannelById;

public sealed record GetChannelByIdQuery(Guid Id) : IRequest<Result<GetChannelByIdResponse>>;
