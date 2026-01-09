using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Users;

namespace SMS.UseCases.Features.Users.UpdateUserProfile;

public sealed record UpdateUserProfileCommand(string GivenName, string? AvatarUrl) : IRequest<Result<Guid>>;
