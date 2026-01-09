using SMS.Core.Common;
using SMS.UseCases.Features.Users.UpdateUserProfile;

namespace SMS.UseCases.Commands.Users;

public interface IUpdateUserProfileService
{
    Task<Result<Guid>> Handle(Guid userId, UpdateUserProfileCommand command, CancellationToken cancellationToken);
}