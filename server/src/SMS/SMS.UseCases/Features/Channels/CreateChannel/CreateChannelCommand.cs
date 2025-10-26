using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Channels.CreateChannel;

public sealed record CreateChannelCommand(
    string DisplayName, 
    string? Description,
    Guid TeamId,
    IReadOnlyList<Guid> OwnerIds,
    IReadOnlyList<Guid> MemberIds) : IRequest<Result<Guid>>;
