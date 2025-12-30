using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Users;

namespace SMS.UseCases.Features.Users.UpdateUserProfile;

public sealed record UpdateUserProfileCommand(Guid Id, string GivenName, DateOnly DateOfBirth, GenderType GenderType, string? AvatarUrl, int CountryId) : IRequest<Result<Guid>>;
