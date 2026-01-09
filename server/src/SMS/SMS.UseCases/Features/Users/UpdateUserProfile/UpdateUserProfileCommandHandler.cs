using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Commands.Users;

namespace SMS.UseCases.Features.Users.UpdateUserProfile;

internal sealed class UpdateUserProfileCommandHandler(
    IUserProvider userProvider,
    IUpdateUserProfileService updateUserProfileService): IRequestHandler<UpdateUserProfileCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(UpdateUserProfileCommand command, CancellationToken cancellationToken)
    {
        var result = await updateUserProfileService.Handle(userProvider.UserId, command, cancellationToken);

        return result.IsFailure ? Result.Failure<Guid>(result.Error) : Result.Success(result.Value);
    }
}
