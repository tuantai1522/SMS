using MediatR;
using SMS.Core.Common;
using SMS.Core.Errors.Users;
using SMS.Core.Features.Users;
using SMS.UseCases.Abstractions.Data;

namespace SMS.UseCases.Features.Users.UpdateUserProfile;

internal sealed class UpdateUserProfileCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository): IRequestHandler<UpdateUserProfileCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(UpdateUserProfileCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindUserByIdAsync(command.Id, cancellationToken);

        if (user == null)
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }

        user.CreateUserProfile(command.GivenName, command.DateOfBirth, command.GenderType, command.AvatarUrl, command.CountryId);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(user.Id);
    }
}
