using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Channels.UpdateChannel;

public sealed record UpdateChannelCommand(Guid Id, string DisplayName, string? Description) : IRequest<Result<Guid>>;
