using SMS.Core.Common;

namespace SMS.Core.Features.Users;

public sealed record UserSignedUpDomainEvent(Guid UserId) : IDomainEvent;
